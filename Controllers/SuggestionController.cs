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
    public class SuggestionController : ControllerBase
    {
        // GET: api/<SuggestionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SuggestionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuggestionController>
        [HttpPost]
        public String Post([FromBody] JsonElement value)
        {
            var action = value.GetProperty("action").GetString();
            if (action.Equals("add"))
            {
                var name = value.GetProperty("name").GetString();
                if (!String.IsNullOrEmpty(name))
                {
                    var entry = new SuggestionEntry();
                    entry.name = name;
                    SuggestionInt.add(entry);
                    return "{'result':0,'message':'提交成功'}";
                }
            }
            return "{'result':1,'message':'提交失败'}";
        }

        // PUT api/<SuggestionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuggestionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
