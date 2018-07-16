using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVErything.Business;
using EVErything.Business.Models;
using EVErything.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EVErything.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        private Repository<Account> repository;

        public AccountsController(Repository<Account> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AccountViewModel>)]
        public IActionResult Get()
        {

            return Ok(repository.Get());
        }
    }
}