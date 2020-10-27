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
    public class QuestionController : ControllerBase
    {
        // GET: api/<QuestionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<QuestionController>/5
        [HttpGet]
        public string Get([FromBody] JsonElement value)
        {
            var start = value.GetProperty("start").GetInt32();
            var len = value.GetProperty("len").GetInt32();
            var searchText = value.GetProperty("searchText").GetString();
            var status = value.GetProperty("status").GetInt32();
            var requestUserId = 0;
            JsonElement jsonEle = new JsonElement();
            if (value.TryGetProperty("userId",out jsonEle))
            {
                requestUserId = jsonEle.GetInt32();
            }

            QuestionInt.GetList(start,len,searchText,status,requestUserId);

            return "value";
        }

        // POST api/<QuestionController>    
        [HttpPost]
        public string Post([FromBody] JsonElement value)
        {
            var action = value.GetProperty("action").GetString();
            if (action.Equals("add"))
            {
                var username = value.GetProperty("username").GetString();
                string title = value.GetProperty("title").GetString();
                var description = value.GetProperty("description").GetString();
                if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(title))
                {
                    var user = UserInt.GetUser(username);
                    if (user != null) { 
                        var entry = new QuestionEntry();
                        entry.name = title;
                        entry.authorId = user.id;
                        entry.description = description;
                        entry.questionTime = DateTime.Now;
                        QuestionInt.add(entry);
                        return "{'result':0,'message':'添加成功'}";
                    }
                }
            }else if (action.Equals("get"))
            {
                var start = value.GetProperty("start").GetInt32();
                var len = value.GetProperty("length").GetInt32();
                var searchText = value.GetProperty("searchText").GetString();
                var status = value.GetProperty("status").GetInt32();
                var requestUserId = 0;
                JsonElement jsonEle = new JsonElement();
                if (value.TryGetProperty("userId", out jsonEle))
                {
                    requestUserId = jsonEle.GetInt32();
                }

                var list = QuestionInt.GetList(start, len, searchText, status, requestUserId);
                var result = new BaseResult();
                result.result = 0;
                result.data = list;
                var seresult= JsonSerializer.Serialize(result);
                return seresult;
            }

            return "{'result':1,'message':'提交失败'}";
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
