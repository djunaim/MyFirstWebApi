using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // get json array data back and place in body
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]

        // use IActionResult to control specificity of Status Codes that come back (i.e., 200, 201, etc...)
        public IActionResult Get(int id)
        {
            if (id == 1000)
            {
                return NotFound("Dumb dumb");
            }

            return Ok(id);
            // getting end of url and assigning it to id 
            //return $"{id}";
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
    }
}
