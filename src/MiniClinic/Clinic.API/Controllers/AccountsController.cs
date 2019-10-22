using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Entitites;
using Clinic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private IAccountsService AccountsService { get; }

        public AccountsController(IAccountsService accountsService)
        {
            AccountsService = accountsService;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string Username,string Password)
        {
            try
            {
                var data = await AccountsService.Login(Username, Password);
                return Ok(new
                {
                    Allow = data.Item2.Item1,
                    Message = data.Item2.Item2,
                    Account = data.Item1,
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAccounts")]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var data = await AccountsService.GetAccounts();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody]Account account)
        {
            try
            {
                var data = await AccountsService.CreateAccount(account);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("ModifyAccount")]
        public async Task<IActionResult> ModifyAccount([FromBody]Account account)
        {
            try
            {
                var data = await AccountsService.ModifyAccount(account);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("RemoveAccount")]
        public async Task<IActionResult> RemoveAccount([FromBody]Account account)
        {
            try
            {
                var data = await AccountsService.RemoveAccount(account);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}