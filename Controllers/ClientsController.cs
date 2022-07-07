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
    public class ClientsController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IClientService _clientService;
        private readonly ICareHomeService _careHomeService;

        public ClientsController(
            IClientService clientService,
            ICareHomeService careHomeService,
            IOptions<AppSettings> appSettings)
        {
            _clientService = clientService;
            _careHomeService = careHomeService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody] Client client)
        {
            //agency.Id = 1;
            _clientService.Create(client);
            var clientHome = _clientService.GetById(client.CareHomeId);

            // return basic user info and authentication token
            return Ok(new
            {
                ClientId = client.ClientId,
                ClientName = client.Name,
                ClientAddress = client.Address,
                ClientDOB = client.DateOfBirth,
                ClientEmail = client.Email,
            });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var clients = _clientService.GetAll();
            return Ok(clients);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = _clientService.GetById(id);
            return Ok(client);
        }

        [AllowAnonymous]
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] Client client)
        {
            if (id != client.ID) return NotFound();

            if (!ModelState.IsValid) return NotFound();
            try
            {
                // update user 
                _clientService.Update(client);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        //[AllowAnonymous]
        //[HttpPut("givemedication/{id}")]
        //public IActionResult GiveMedication(int id, [FromBody] Client client)
        //{
        //    if (id != client.ID) return NotFound();

        //    if (!ModelState.IsValid) return NotFound();
        //    try
        //    {
        //        // update user 
        //        _clientService.GiveMedication(client);
        //        return Ok();
        //    }
        //    catch (AppException ex)
        //    {
        //        // return error message if there was an exception
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}

        [AllowAnonymous]
        [HttpGet("homes")]
        public IActionResult GetAllHomes()
        {
            var clientshomes = _clientService.GetClientHome();
            return Ok(clientshomes);
        }

        [AllowAnonymous]
        [HttpGet("medication/{id}")]
        public IActionResult GetClientMedication(int id)
        {
            var clientsMedication = _clientService.GetClientMedication(id);
            return Ok(clientsMedication);
        }

        [AllowAnonymous]
        [HttpPost("createmedication")]
        public IActionResult CreateMedication([FromBody] Medication medication)
        {
            //agency.Id = 1;
            _clientService.CreateMedication(medication);
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clientService.Delete(id);
            return Ok();
        }
    }
}
