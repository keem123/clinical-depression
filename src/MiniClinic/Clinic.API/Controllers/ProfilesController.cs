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
    [Route("api/People")]
    public class ProfilesController : Controller
    {
        public IPersonService PersonService { get; }

        public ProfilesController(IPersonService personService)
        {
            //asdfasfsa
            PersonService = personService;
        }
        [HttpGet("GetProfiles")]
        public async Task<IActionResult> CreateProfile(int Limit = 500)
        {
            try
            {
                var data = await PersonService.GetPeople(Limit);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetPersonCategories()
        {
            try
            {
                var data = await PersonService.GetPersonCategories();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateProfile")]
        public async Task<IActionResult> CreateProfile([FromBody]Person person)
        {
            try
            {
                var data = await PersonService.CreateProfile(person);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("ModifyProfile")]
        public async Task<IActionResult> ModifyProfile([FromBody]Person person)
        {
            try
            {
                var data = await PersonService.ModifyProfile(person);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("RemoveProfile")]
        public async Task<IActionResult> RemoveProfile([FromBody]Person person)
        {
            try
            {
                var data = await PersonService.RemoveProfile(person);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}