using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private AppDatabaseContext _DbContext;

        //внедрение зависимости
        public WeatherForecastController(AppDatabaseContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var users = _DbContext.Users.Select(u => u.Name).ToArray();
            return users;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _DbContext.Users.Find(id).Name;
        }

        [HttpPost]
        public void Post([FromBody] string value , int value2)
        {
            User user = new User();

            user.Name = value;
            user.Age = 20;

            _DbContext.Users.Add(user);
            _DbContext.SaveChanges();
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            User user = _DbContext.Users.Find(id);
            user.Name = value;

            _DbContext.SaveChanges();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            User user = _DbContext.Users.Find(id);
            _DbContext.Users.Remove(user);

            _DbContext.SaveChanges();
        }

    }
}
