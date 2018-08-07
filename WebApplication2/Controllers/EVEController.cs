using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.ESIViewModels;

namespace WebApplication2.Controllers
{
    public class EVEController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EVEController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("/main")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet("/api/character")]
        public async Task<IActionResult> GetCharacter()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = new VerifyViewModel
            {
                CharacterID = user.CharacterId,
                CharacterName = user.CharacterName
            };

            return Ok(model);
        }
    }
}
