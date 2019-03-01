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
    //[Route("api/")]
    [ApiController]
    public class ESIController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        private IEVEDataService _eveDataService;

        private IConfiguration Configuration { get; }
        public object ESIService { get; private set; }

        public ESIController(UserManager<ApplicationUser> userManager, ILogger<EVEController> logger, IConfiguration configuration, IEVEDataService eveDataService)
        {
            _userManager = userManager;
            _logger = logger;
            _eveDataService = eveDataService;
            Configuration = configuration;
        }

        /// <summary>
        /// Example path:
        ///  /api/esi?esipath=characters/1111/attributes
        /// </summary>
        /// <param name="esipath"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("api/esip")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> PostESIData([FromForm] string esipath)
        {
            var user = await _userManager.GetUserAsync(User);
            _logger.LogTrace("POST esipath: " + esipath);
            _logger.LogTrace("eveDataService is null? " + (_eveDataService == null));
            return Ok(_eveDataService.GetEVEData("1111", esipath));
            //return Ok("{result:'ok post: " + esipath + "'}");
        }

        [HttpGet("api/esi")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetESIData([FromQuery] string esipath)
        {
            var user = await _userManager.GetUserAsync(User);

            _logger.LogTrace("GET esipath: " + esipath);
            return Ok(_eveDataService.GetEVEData("1111", esipath));
            //return Ok("{result:'ok get: " + esipath + "'}");
        }
    }

}