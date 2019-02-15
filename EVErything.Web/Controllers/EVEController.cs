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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace EVErything.Web.Controllers
{
    public class EVEController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly ILogger _logger;
        private IConfiguration Configuration { get; }

        public EVEController(UserManager<ApplicationUser> userManager, AppDbContext appDbContext, ILogger<EVEController> logger, IConfiguration configuration)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _logger = logger;
            Configuration = configuration;
        }

        [Authorize]
        [HttpGet("/main")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [AllowCrossSiteJson]
        [HttpGet("/api/characters")]
        [ProducesResponseType(200, Type = typeof(List<Character>))]
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

        [Authorize]
        [HttpDelete("/api/characters/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteCharacter([FromRoute] string id)
        {
            _logger.LogTrace($"Delete char with id [{id}]");
            return Ok();
        }

        [Authorize]
        [HttpPost("/esi")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetESIData([FromBody] string esipath)
        {
            return Ok("{result:'ok'}");
        }
    }
}
