﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebApplication2.Models;
using Microsoft.Extensions.Logging;
using WebApplication2.Controllers;
using WebApplication2.Models.ESIViewModels;

namespace WebApplication1.Controllers
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

        public AuthenticationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AuthenticationController> logger,
            IHttpClientFactory clientFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        [Route("esicallback")]
        public async Task<IActionResult> ESICallback([FromQuery] string code)
        {
            Console.WriteLine("Code from esi" + code);
            //var request = new HttpRequestMessage(HttpMethod.Post, "https://sisilogin.testeveonline.com/oauth/token");
            //request.Headers.Add("Content-Type", "application/json");

            //request.Headers.Add("Host", "sisilogin.testeveonline.com");
            //request.Content = new StringContent("{\"grant_type\"=\"authorization_code\", \"code\"=\"" + code + "\"}");

            var client = _clientFactory.CreateClient();
            //client.BaseAddress = new Uri("https://sisilogin.testeveonline.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "de2dbc0324ec4fc583a1aa0b18cfb08b", "4NLiCtkhHBeo8bmXYICVBfur9Oq5yAuNcDbTJYCn"))));
            //var content = new MultipartFormDataContent();
            //content.Add(new StringContent("grant_type=authorization_code&code=" + code));

            HttpResponseMessage response = await client.PostAsync(new Uri("https://sisilogin.testeveonline.com/oauth/token"), new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", code)
                })).ConfigureAwait(false);
            //var response = await client.PostAsync("oauth/token", content);

            string contentResponse = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<AccessToken>(contentResponse);
            Console.WriteLine("Content: " + contentResponse);
            Console.WriteLine("Access_token: " + token.access_token);

            var esiclient = _clientFactory.CreateClient();
            esiclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
            // Iam Outamon2 = 2113547503
            // Inna Numa = 2113884986
            response = await esiclient.GetAsync("https://esi.evetech.net/verify?datasource=singularity");

            var character = await response.Content.ReadAsStringAsync();
            Console.WriteLine("character: " + character);
            var verify = JsonConvert.DeserializeObject<VerifyViewModel>(character);

            var user = await _userManager.FindByNameAsync(verify.CharacterID);

            if (user == null)
            {
                // Create the user 
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

            // login
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction(nameof(EVEController.Index), "EVE");
        }
    }
}