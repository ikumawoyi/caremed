using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class CareHomesController : ControllerBase
	{
		private readonly AppSettings _appSettings;
		private readonly ICareHomeService _careHomeService;

		public CareHomesController(
			ICareHomeService careHomeService,
			IOptions<AppSettings> appSettings)
		{
			_careHomeService = careHomeService;
			_appSettings = appSettings.Value;
		}

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody] CareHome careHome)
        {
            //agency.Id = 1;
            _careHomeService.Create(careHome);

            // return basic user info and authentication token
            return Ok(new
            {
                CareHomeId = careHome.CareHomeId,
                CareHomeName = careHome.Name,
                CareHomePhoneNumber = careHome.PhoneNumber,
                CareHomeAddress = careHome.Address,
                CareHomeContactPerson = careHome.ContactPerson,
                CareHomeEmail = careHome.Email
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var careHomes = _careHomeService.GetAll();
            return Ok(careHomes);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var careHome = _careHomeService.GetById(id);
            return Ok(careHome);
        }

        [AllowAnonymous]
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] CareHome careHome)
        {
            if (id != careHome.ID) return NotFound();

            if (!ModelState.IsValid) return NotFound();
            try
            {
                // update user 
                _careHomeService.Update(careHome);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _careHomeService.Delete(id);
            return Ok();
        }
    }
}
