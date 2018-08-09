using EVErything.Business;
using EVErything.Business.Models;
using EVErything.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EVErything.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/characters")]
    public class CharacterController : Controller
    {
        private Repository<Character> repository;

        public CharacterController(Repository<Character> repository)
        {
            this.repository = repository;
        }

        // GET: api/Character
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.Get());
        }

        // GET: api/Character/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            return Ok(repository.Get(id));
        }
        
        // POST: api/Character
        [HttpPost]
        public IActionResult Post([FromBody]CharacterViewModel character)
        {
            var newChar = repository.Insert(new Character { Name = character.Name });
            repository.SaveChanges();

            return Ok(newChar);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            repository.Delete(id);
            return Ok();
        }
    }
}
