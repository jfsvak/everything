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

        private IConfiguration Configuration { get; }

        public HomeController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            Configuration = configuration;
        }

        public IActionResult Index()
        { 
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

        //public IActionResult ExternalAuth()
        //{
        //    var callbackUrl = Url.Action("https://sisilogin.testeveonline.com/oauth/authorize?response_type=code&redirect_uri=http%3A%2F%2Flocalhost%3A5001%2Fesicallback&client_id=de2dbc0324ec4fc583a1aa0b18cfb08b&scope=characterAccountRead%20characterKillsRead%20characterSkillsRead%20esi-skills.read_skills.v1");

        //    var props = new AuthenticationProperties
        //    {
        //        RedirectUri = callbackUrl,
        //        Items =
        //        {
        //            { "scheme", "" },
        //            { "returnUrl", "http://localhost:5001/esicallback" }
        //        }
        //    };

        //    return Challenge("", props);
        //}

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

        [HttpGet]
        public IActionResult EVESSoRedirect()
        {
            var url = $"{Configuration["EVE:SSO.Url"]}/oauth/authorize";
            var responseType = "code";
            var redirectUri = Uri.EscapeDataString($"{Configuration["EVE:ESI.Callback.URL"]}");
            var clientId = Configuration["EVE:clientId"];
            var scope = Uri.EscapeDataString("characterAccountRead characterKillsRead characterSkillsRead esi-skills.read_skills.v1");
            
            return Redirect(url + "?response_type=" + responseType + "&redirect_uri=" + redirectUri + "&client_id=" + clientId + "&scope=" + scope);
        }
    }
}
