using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Working.Models;

namespace Working.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        private WorkingContext db;

        public FriendsController(WorkingContext context) {
            db = context;
        }
        
        // GET api/friends
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(db.Friends.ToList());
        }

        // GET api/friends/5
        [HttpGet("{id}", Name = "GetOne")]
        public IActionResult Get(int id)
        {
            Friend friend = db.Friends.FirstOrDefault(x => x.Id == id);

            if(friend == null)
            {
                return NotFound();
            }

            return Ok(friend);
        }

        // POST api/friends
        [HttpPost]
        public IActionResult Post([FromBody]Friend friend)
        {
            db.Add(friend);
            int save = db.SaveChanges();

            if(save > 0) {
                return CreatedAtRoute("GetOne", new {controller = "Friends", id = friend.Id}, friend);
            }

            return BadRequest();
        }

        // PUT api/friends/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Friend friendUpdate)
        {
            if(friendUpdate == null) {
                return BadRequest();
            }

            Friend friend = db.Friends.FirstOrDefault(x => x.Id == id);
            if(friend == null) {
                return NotFound();
            }

            friend.Name = friendUpdate.Name;
            int save = db.SaveChanges();

            if(save > 0) {
                return Ok(friend);
            }
            
            return BadRequest();
        }

        // DELETE api/friends/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Friend friend = db.Friends.FirstOrDefault(x => x.Id == id);
            if(friend == null) {
                return NotFound();
            }

            db.Remove(friend);
            int save = db.SaveChanges();

            if(save > 0) {
                return Ok(friend);
            }
            
            return BadRequest();
        }
    }
}
