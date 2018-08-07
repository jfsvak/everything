using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
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
    }
}
