using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HospitalMachine.DB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        // GET: api/<UpdateController>
        [HttpGet]
        public String Get()
        {
            var value = ConfigsInt.getValue("android_update");            
            return value;
        }

        // GET api/<UpdateController>/5
        [HttpGet("{device}")]
        public string Get(String device)
        {
            return "";
        }

        // POST api/<UpdateController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UpdateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UpdateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
