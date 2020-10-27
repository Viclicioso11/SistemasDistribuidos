using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using BaseArquitecturaAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/test")]
    public class ValuesController : BaseController
    {
        private readonly IEmailService _service;
        public ValuesController(IEmailService service)
        {
            _service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAllTests()
        {
            return Ok();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestValueById(int id)
        {
            //var response = await Mediator.Send(new GetTestByIdQuery { TestId = id});

            return Ok();
        }

        // GET api/<controller>/5
        [HttpPost()]
        public async Task<IActionResult> PostCreateTest()
        {
            await _service.SendEmail("victorabud11@gmail.com", "Prueba desde API", "Prueba1");

            return Ok();
        }

    }
}
