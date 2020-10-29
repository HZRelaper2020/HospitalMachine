using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HospitalMachine.DB;
using HospitalMachine.entry;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        // GET: api/<AnswerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnswerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AnswerController>
        [HttpPost]
        public String Post([FromBody] JsonElement value)
        {
            var result = new BaseResult();
            var action = value.GetProperty("action").GetString();
            if (action.Equals("getByQuestionId"))
            {
                var questionId = value.GetProperty("questionId").GetInt32();
                var list = AnswerInt.getByQuestionId(questionId);
                result.result = 0;
                result.data = list;
                var seresult = JsonSerializer.Serialize(result);
                return seresult;

            }
            else if (action.Equals("add"))
            {
                var entry = new AnswerEntry();

                var username = value.GetProperty("username").GetString();
                entry.questionId = value.GetProperty("questionId").GetInt32();
                entry.answerBody = value.GetProperty("answerBody").GetString();
                entry.userId = UserInt.GetUser(username).id;                
                AnswerInt.addAnswer(entry);
                result.result = 0;
                var seresult = JsonSerializer.Serialize(result);
                return seresult;
            }
            return "{'result':1,'message':'提交失败'}";
        }

        // PUT api/<AnswerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnswerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
