using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVErything.Business.Data;
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
        [HttpGet("/api/characters")]
        public async Task<IActionResult> GetCharacters()
        {
            var user = await _userManager.GetUserAsync(User);

            using (var ctx = new AppDbContext())
            {
                var characters = ctx.Characters.Where(c => c.CharacterSet.MainCharacterID == user.CharacterId).ToList();

                return Ok(characters);
            }
        }
    }
}
