using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVErything.Business.Data;
using EVErything.Business.Services;
using EVErything.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EVErything.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ESIController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly ILogger _logger;
        private IConfiguration Configuration { get; }
        public object ESIService { get; private set; }

        public ESIController(UserManager<ApplicationUser> userManager, AppDbContext appDbContext, ILogger<EVEController> logger, IConfiguration configuration)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _logger = logger;
            Configuration = configuration;
        }

        /// <summary>
        /// Example path:
        ///  /api/esi?esipath=characters/1111/attributes
        /// </summary>
        /// <param name="esipath"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("api/esi")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetESIData([FromQuery] string esipath)
        {
            var user = await _userManager.GetUserAsync(User);

            using (_appDbContext)
            {
                return Ok(new EVEDataService(_appDbContext).GetEVEData(user.CharacterId, esipath));
            }
            //return Ok("{result:'ok'}");
        }
    }

}