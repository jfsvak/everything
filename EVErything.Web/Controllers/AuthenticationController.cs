using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EVErything.Web.Models;
using Microsoft.Extensions.Logging;
using EVErything.Web.Models.ESIViewModels;
using EVErything.Business.Data;
using EVErything.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace EVErything.Web.Controllers
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }

    public class AuthenticationController : Controller
    {

        private readonly IHttpClientFactory _clientFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly AppDbContext _appDbContext;

        public AuthenticationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AuthenticationController> logger,
            IHttpClientFactory clientFactory,
            AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _clientFactory = clientFactory;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        [Route("esicallback")]
        public async Task<IActionResult> ESICallback([FromQuery] string code)
        {
            _logger.LogInformation("Code from esi" + code);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "de2dbc0324ec4fc583a1aa0b18cfb08b", "4NLiCtkhHBeo8bmXYICVBfur9Oq5yAuNcDbTJYCn"))));

            // Exchange the received auth code for a token list
            HttpResponseMessage response = await client.PostAsync(new Uri("https://sisilogin.testeveonline.com/oauth/token"), new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", code)
                })).ConfigureAwait(false);

            string contentResponse = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<AccessToken>(contentResponse);
            _logger.LogInformation("Content: " + contentResponse);
            _logger.LogInformation("Access_token: " + token.access_token);

            // Verify token
            var esiclient = _clientFactory.CreateClient();
            esiclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            response = await esiclient.GetAsync("https://esi.evetech.net/verify?datasource=singularity");

            var verifyString = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("character: " + verifyString);

            var verify = JsonConvert.DeserializeObject<VerifyViewModel>(verifyString);

            // if the verify object at this point contains the CharacterID, I know the auth went well, and I can start the local login flow:
            // 1. Find the User with verify.CharacterID in my Identity database
            //   1.a If found, then sign him in:
            //   1.b If not found, create a new User with that CharacterID.
            // 2. Find Character with CharacterID
            //  2.a If not found -> create Character + new CharacterSet and set new Character as Main on set
            // 3. Update tokens in AppDb
            // 4. Sign in user as the last thing, so all subsequent requests are Authed against the signed in user, and token is updated

            var user = await _userManager.FindByNameAsync(verify.CharacterID);

            if (user == null)
            {
                // If user not found for that CharacterID, create a new user 
                user = new ApplicationUser
                {
                    UserName = verify.CharacterID,
                    CharacterId = verify.CharacterID,
                    AccessToken = token.access_token,
                    RefreshToken = token.refresh_token,
                    CharacterName = verify.CharacterName
                };

                var identityResult = await _userManager.CreateAsync(user, verify.CharacterID);
            }

            using(_appDbContext)
            {
                var character = _appDbContext.Characters.Find(verify.CharacterID);

                if (character == null)
                    character = _appDbContext.Characters.Add(new Character { ID = verify.CharacterID, Name = verify.CharacterName, CharacterSet = new CharacterSet() }).Entity;

                var tokens = _appDbContext.Tokens.Find(character.ID);

                if (tokens == null)
                {
                    _appDbContext.Tokens.Add(new Token { Character = character, AccessToken = token.access_token, RefreshToken = token.refresh_token, ExpiresIn = token.expires_in, TokenType = token.token_type});
                } else
                {
                    tokens.AccessToken = token.access_token;
                    tokens.RefreshToken = token.refresh_token;
                    tokens.ExpiresIn = token.expires_in;
                    tokens.TokenType = token.token_type;
                    _appDbContext.Entry(tokens).State = EntityState.Modified;
                }
                _appDbContext.SaveChanges();
            }

            // sign in user
            await _signInManager.SignInAsync(user, false);

            // Redirect to ReactApp
            return RedirectToAction(nameof(EVEController.Index), "EVE");
        }
    }
}