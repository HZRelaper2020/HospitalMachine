using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HospitalMachine.DB;
using HospitalMachine.entry;
using Microsoft.AspNetCore.Mvc;
using static HospitalMachine.DB.UserInt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public string Post([FromBody] JsonElement value)
        {
            var loginresult = new LoginResult();
            var action = value.GetProperty("action").GetString();
            if ("login".Equals(action))
            {
                var username = value.GetProperty("username").GetString();
                var role = UserInt.GetUser(username);
                if (role != null)
                {
                    //var roleStr = JsonSerializer.Serialize(role);
                    
                    loginresult.result = 0;
                    loginresult.data = role;
                }
                else
                {
                    loginresult.result = 1;
                    loginresult.message = "no such user " + username;                    
                }
            }
            else
            {
                loginresult.result = 1;
                loginresult.message = "no such action " + action;
            }
            var resultstr = JsonSerializer.Serialize(loginresult);
            return resultstr;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "111111";
        }
    }
}
