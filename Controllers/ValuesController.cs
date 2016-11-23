using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Working.Models;

namespace Working.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private WorkingContext db;

        public ValuesController(WorkingContext context) {
            db = context;
        }
        
        // GET api/values
        [HttpGet]
        public IEnumerable<Friend> Get()
        {
            var friends = db.Friends.ToList();
            return friends;
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
            string[] test = {"1", "2"};
        }
    }
}
