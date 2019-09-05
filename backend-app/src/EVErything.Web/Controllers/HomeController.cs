using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EVErything.Web.Models;
using EVErything.Web.Models.ESIViewModels;
using Microsoft.Extensions.Configuration;
using EVErything.Business.Data;
using EVErything.Business.Models;

namespace EVErything.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _appDbContext;

        private IConfiguration Configuration { get; }

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Configuration = configuration;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        { 
            if(_signInManager.IsSignedIn(User))
            {
                return RedirectToAction(nameof(EVEController.Index), "EVE");
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["Content"] = $"User Name: {User.Identity.Name}";
            Console.WriteLine($"User Name: {User.Identity.Name}");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task Login(string returnUrl = null)
        {
            await HttpContext.ChallengeAsync("EVESSO", new AuthenticationProperties() { RedirectUri = returnUrl });
        }

        public IActionResult LoginExternal(string returnUrl = null)
        {
            var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties("EVESSO", Url.Action(nameof(HandleExternalLogin), "Home", new { returnUrl }));
            return Challenge(authenticationProperties, "EVESSO");
        }

        public async Task<IActionResult> HandleExternalLogin(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                Console.WriteLine("Error loading external login information during confirmation.");

                return RedirectToPage("./Error", new { ReturnUrl = returnUrl });
            }

            var user = await _userManager.FindByIdAsync(info.ProviderKey);

            if (user == null)
            {
                Console.WriteLine($"Identity not found for name [{info.ProviderKey}]");
                // If user not found for that CharacterID, create a new user 
                user = new ApplicationUser
                {
                    Id = info.ProviderKey,
                    UserName = info.Principal.Claims.Where(c => c.Type.Equals("characterid")).First().Value,
                    CharacterId = info.Principal.Claims.Where(c => c.Type.Equals("characterid")).First().Value,
                    //AccessToken = info.Principal.token.access_token,
                    //RefreshToken = token.refresh_token,
                    CharacterName = info.Principal.Claims.Where(c => c.Type.Equals("charactername")).First().Value
                };

                var identityResult = await _userManager.CreateAsync(user, info.ProviderKey);
            }

            using (_appDbContext)
            {
                var character = _appDbContext.Characters.Find(info.ProviderKey);

                if (character == null)
                    character = _appDbContext.Characters.Add(new Character { ID = info.ProviderKey, Name = info.Principal.Claims.Where(c => c.Type.Equals("charactername")).First().Value, CharacterSet = new CharacterSet() }).Entity;

                var tokens = _appDbContext.Tokens.Find(character.ID);

                //if (tokens == null)
                //{
                //    _appDbContext.Tokens.Add(new Token { Character = character, AccessToken = token.access_token, RefreshToken = token.refresh_token, ExpiresIn = token.expires_in, TokenType = token.token_type });
                //}
                //else
                //{
                //    tokens.AccessToken = token.access_token;
                //    tokens.RefreshToken = token.refresh_token;
                //    tokens.ExpiresIn = token.expires_in;
                //    tokens.TokenType = token.token_type;
                //    _appDbContext.Entry(tokens).State = EntityState.Modified;
                //}
                _appDbContext.SaveChanges();
            }

            // sign in user
            await _signInManager.SignInAsync(user, false);
            //var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            return Redirect(returnUrl);
        }

        [Route("/Home/PostLogin")]
        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                Console.WriteLine("Error loading external login information during confirmation.");

                return RedirectToPage("./Error", new { ReturnUrl = returnUrl });
            }

            return RedirectToAction(nameof(HomeController.About), "Home");
            //var user = await _userManager.FindByNameAsync(verify.CharacterID);

            //if (user == null)
            //{
            //    // If user not found for that CharacterID, create a new user 
            //    user = new ApplicationUser
            //    {
            //        UserName = verify.CharacterID,
            //        CharacterId = verify.CharacterID,
            //        AccessToken = token.access_token,
            //        RefreshToken = token.refresh_token,
            //        CharacterName = verify.CharacterName
            //    };

            //    var identityResult = await _userManager.CreateAsync(user, verify.CharacterID);
            //}

            //using (_appDbContext)
            //{
            //    var character = _appDbContext.Characters.Find(verify.CharacterID);

            //    if (character == null)
            //        character = _appDbContext.Characters.Add(new Character { ID = verify.CharacterID, Name = verify.CharacterName, CharacterSet = new CharacterSet() }).Entity;

            //    var tokens = _appDbContext.Tokens.Find(character.ID);

            //    if (tokens == null)
            //    {
            //        _appDbContext.Tokens.Add(new Token { Character = character, AccessToken = token.access_token, RefreshToken = token.refresh_token, ExpiresIn = token.expires_in, TokenType = token.token_type });
            //    }
            //    else
            //    {
            //        tokens.AccessToken = token.access_token;
            //        tokens.RefreshToken = token.refresh_token;
            //        tokens.ExpiresIn = token.expires_in;
            //        tokens.TokenType = token.token_type;
            //        _appDbContext.Entry(tokens).State = EntityState.Modified;
            //    }
            //    _appDbContext.SaveChanges();
            //}

            //// sign in user
            //await _signInManager.SignInAsync(user, false);

            //// Redirect to ReactApp
            //return RedirectToAction(nameof(EVEController.Index), "EVE");
        }

        public async Task LoginSSO(string returnUrl = null)
        {
            await HttpContext.ChallengeAsync("EVESSO", new AuthenticationProperties() { RedirectUri = "/Home/PostLogin" });
        }

        public IActionResult Logout()
        {
            return Ok();
        }

        [Authorize]
        public async Task<IActionResult> CharacterDetails()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new VerifyViewModel
            {
                CharacterID = user.CharacterId,
                CharacterName = user.CharacterName
            };

            return View(model);
        }

        [HttpGet("/Home/EVESSoRedirect")]
        public IActionResult EVESSoRedirect()
        {
            var url = $"{Configuration["EVE:SSO.Url"]}/oauth/authorize";
            var responseType = "code";
            var redirectUri = Uri.EscapeDataString(Environment.GetEnvironmentVariable("ESI_CALLBACK_URL"));
            var clientId = Environment.GetEnvironmentVariable("EVE_CLIENT_ID");
            var scope = Uri.EscapeDataString("esi-skills.read_skillqueue.v1 esi-skills.read_skills.v1");
            
            return Redirect(url + "?response_type=" + responseType + "&redirect_uri=" + redirectUri + "&client_id=" + clientId + "&scope=" + scope);
        }
    }
}
