using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        DataBase _db;

        //внедрение зависимости
        public WeatherForecastController(DataBase db) => this._db = db;

        [HttpGet]
        public IEnumerable<string> Get() => _db;
        

        [HttpPost]
        public void Post([FromBody] string value) => _db.Add(value);


        [HttpGet("{index}")]
        public string Get(int index) => _db[index];
              

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) => _db[id] = value;
        

        [HttpDelete("{value}")]
        public void Delete(string value) => _db.Remove(value);
        
    }
}
