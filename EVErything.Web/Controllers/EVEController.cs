using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVErything.Business.Data;
using EVErything.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EVErything.Web.Models;
using EVErything.Web.Models.ESIViewModels;

namespace EVErything.Web.Controllers
{
    public class EVEController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;

        public EVEController(UserManager<ApplicationUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        [Authorize]
        [HttpGet("/main")]
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        [AllowCrossSiteJson]
        [HttpGet("/api/characters")]
        public async Task<IActionResult> GetCharacters()
        {
            var user = await _userManager.GetUserAsync(User);
            //var characters = new List<Character>();

            using (_appDbContext)
            {
                var character = _appDbContext.Characters.Find(user.CharacterId);
                var characters = _appDbContext.Characters.Where(c => c.CharacterSetID == character.CharacterSetID).ToList();
                return Ok(characters);
            }

        }
    }
}
