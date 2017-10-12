using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dummyDb.Db;
using dummyDb.Models;
using Newtonsoft.Json.Linq;
using dummyDb.Services;

namespace dummyDb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DummyDbContext dbContext;
        private readonly IUselessity uselessity;

        public ValuesController(DummyDbContext dbContext, IUselessity uselessity)
        {
            this.dbContext = dbContext;
            this.uselessity = uselessity;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("addstudent")]
        public IActionResult AddStudent()
        {
            try
            {
                string requestPayload = new StreamReader(Request.Body).ReadToEnd();
                var requestJson = JObject.Parse(requestPayload);
                Student student = new Student()
                {
                    LastName = (string)requestJson["lastname"],
                    FirstMidName = uselessity.Serve((string)requestJson["firstmidname"]),
                    EnrollmentDate = DateTime.Now
                };

                dbContext.Students.Add(student);
                dbContext.SaveChanges();

                return Json(student);
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error occured with message: " + e.Message);
                return StatusCode(500);
            }
        }
    }
}
