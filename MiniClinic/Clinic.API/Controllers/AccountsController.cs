using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        public AccountsController()
        {

        }

        public async Task<IActionResult> Login(string Username,string Password)
        {
            try
            {
                return Ok(true);
            }
            catch
            {
                return BadRequest(false);
            }
        }
    }
}