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
    public class StaffsController : ControllerBase
    {
        //private IUserService _userService;
        //private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IStaffService _staffService;

        public StaffsController(
            IStaffService staffService,
            IOptions<AppSettings> appSettings)
        {
            _staffService = staffService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Staff staff)
        {
            //agency.Id = 1;
            _staffService.Create(staff);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = staff.Id,
                AgencyId = staff.StaffId,
                AgencyName = staff.Name,
                PhoneNumber = staff.PhoneNumber,
                Address = staff.Agency,
                ContactNumber = staff.OtherSkill,
                Email = staff.Email,
                WeeklyWorkingHours = staff.WeeklyWorkingHours
            });
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var staffs = _staffService.GetAll();
            return Ok(staffs);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var staff = _staffService.GetById(id);
            return Ok(staff);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Staff staff)
        {
            try
            {
                // update user 
                _staffService.Update(staff);
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
            _staffService.Delete(id);
            return Ok();
        }
    }
}
