using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AgenciesController : ControllerBase
    {
        //private IUserService _userService;
        //private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IAgencyService _agencyService;

        public AgenciesController(
            IAgencyService agencyService,
            IOptions<AppSettings> appSettings)
        {
            _agencyService = agencyService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Agency agency)
        {
            //agency.Id = 1;
            _agencyService.Create(agency);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = agency.Id,
                AgencyId = agency.AgencyId,
                AgencyName = agency.AgencyName,
                PhoneNumber = agency.PhoneNumber,
                Address = agency.Address,
                ContactNumber = agency.ContractNumber,
                Email = agency.Email,
                WeeklyWorkingHours = agency.WeeklyWorkingHours
            });
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var agencies = _agencyService.GetAll();
            return Ok(agencies);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var agency = _agencyService.GetById(id);
            return Ok(agency);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Agency agency)
        {
            try
            {
                // update user 
                _agencyService.Update(agency);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _agencyService.Delete(id);
            return Ok();
        }
    }
}
