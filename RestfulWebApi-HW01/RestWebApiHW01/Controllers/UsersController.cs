using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User = RestWebApiHW01.Models.User;

namespace RestWebApiHW01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static IList<User> _users = new List<User>
        {
            new User
            {
                FirstName = "Gjorgji",
                LastName = "Kongulovski",
                Age = 34,
                Id = 1
            },

            new User
            {
                FirstName = "Chun",
                LastName = "Li",
                Age = 20,
                Id = 2
            },

            new User
            {
                FirstName = "Lara",
                LastName = "Croft",
                Age = 17,
                Id = 3
            },

            new User
            {
                FirstName = "Solid",
                LastName = "Snake",
                Age = 40,
                Id = 4
            },

            new User
            {
                FirstName = "Jin",
                LastName = "Kazama",
                Age = 15,
                Id = 5
            },

            new User
            {
                FirstName = "Yennefer",
                LastName = "Vengerberg",
                Age = 100,
                Id = 6
            },

            new User
            {
                FirstName = "Geralt",
                LastName = "Rivia",
                Id = 7
            },

        };

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            return Ok(_users);
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<User>> GetUserId(int id)
        {
            User users = _users.FirstOrDefault(x => x.Id == id);
            if (null == users)
            {
                return NotFound($"The User with ID: {id} does not exist. Please try again!!!");
            }

            return Ok(users);

        }

        // GET api/users/adults
        [HttpGet("{id}/{adults}")]
        public ActionResult<IEnumerable<User>> GetUserAdult(int id)
        {
            User users = _users.FirstOrDefault(x => x.Id == id);

            if (null == users)
            {
                return NotFound($"The User with ID: {id} does not exist. Please try again!!!");
            }

            if (users.Age < 18)
            {
                return Ok($"The User {users.FirstName} {users.LastName} with ID: {id} is not an adult.");
            }

            return Ok($"The User {users.FirstName} {users.LastName} with ID: {id} is an adult.");

        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> PostUsers([FromBody] User use)
        {
            User newUser = new User
            {
                Id = _users.Count() + 1,
                FirstName = use.FirstName,
                LastName = use.LastName,
                Age = use.Age
            };

            _users.Add(newUser);
            return Ok("New User has been added to the database.");

        }

        //PUT api/users
        [HttpPut("{id}")]
        public void PutUsers(int id, [FromBody] User user)
        {
            _users[id - 1] = user;

        }

        //DELETE api/users
        [HttpDelete("id")]
        public void DeleteUsers(int id)
        {
            _users.Remove(_users.FirstOrDefault(x => x.Id == id));

        }

    }
}