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
    public class MedicationsController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IMedicationService _medicationService;

        public MedicationsController(
            IMedicationService medicationService,
            IOptions<AppSettings> appSettings)
        {
            _medicationService = medicationService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Medication medication)
        {
            //agency.Id = 1;
            _medicationService.Create(medication);



            return Ok(new
            {
                MedicationId = medication.MedicationID,
                MedicationName = medication.Name,
                MedicationClient = medication.ClientID,
                MedicationManufacturer = medication.Manufacturer,
                MedicationStrength = medication.Strength,
                MedicationForm = medication.Form,
                MedicationEmail = medication.Email,
                MedicationCountOfRemainder = medication.CountOfRemainder,
                MedicationCountOfSupply = medication.CountOfSupply
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var medication = _medicationService.GetAll();
            return Ok(medication);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var medication = _medicationService.GetById(id);
            return Ok(medication);
        }

        [AllowAnonymous]
        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] Medication medication)
        {
            try
            {
                // update user 
                _medicationService.Update(medication);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult GiveMedication([FromBody] Medication medication)
        {
            try
            {
                // update user 
                _medicationService.GiveMedication(medication);
                return Ok(new {
                    MedicationDose = medication.Dose,
                    MedicationStatus = medication.IsGiven,
                    MedicationGivenTime = medication.TimeGiven,
                    MedicationCountOfRemainder = medication.CountOfRemainder,
                    MedicationCountOfSupply = medication.CountOfSupply
                });
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
            _medicationService.Delete(id);
            return Ok();
        }
    }
}
