using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESIClient.Dotcore.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVErything.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/EVEGeneral")]
    public class EVEGeneralController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var charApi = new CharacterApi();
            charApi.GetCharactersCharacterId();
            //ViewBag.Message = "Denne side er til testing ";

                //Server status API
            var apiInstance = new AllianceApi();
            
            var status = new StatusApi();
            var serverStatus = status.GetStatus();

            //ViewBag.Status = serverStatus.Players; //Kalder serverstatus til about siden

            //System kills API
            var universeApi = new UniverseApi();

            var systemKills = universeApi.GetUniverseSystemKills();
            foreach (var kill in systemKills)
            {
                var system = universeApi.GetUniverseSystemsSystemId(kill.SystemId);
                // do something with system.Name;
            }
            var kills = systemKills;
            //ViewBag.Kills = systemKills;

                //Sorteret kills mere end 10 kills
            var sortedKills = systemKills.Where(p => p.ShipKills > 10);
            //ViewBag.SortedKills = sortedKills.ToList();

            return Ok(sortedKills.ToList());
        }
    }
}