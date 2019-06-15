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

namespace EVErything.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private IConfiguration Configuration { get; }

        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            Configuration = configuration;
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

        public async Task Login(string returnUrl = "http://localhost:5001/esicallback")
        {
            await HttpContext.ChallengeAsync("esi", new AuthenticationProperties() { RedirectUri = returnUrl });
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
