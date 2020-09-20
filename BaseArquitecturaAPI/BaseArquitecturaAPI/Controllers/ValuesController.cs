using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseArquitecturaAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseArquitecturaAPI.Controllers
{
    [Route("api/test")]
    public class ValuesController : BaseController
    {
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
        public async Task<IActionResult> PostCreateTest([FromBody] CreateTestModelJson body)
        {
            //var response = await Mediator.Send(new CreateTestCommand { Descripcion = body.Description, Id = body.Id});

            return Ok();
        }

    }
}
