using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstWebApi.Controllers
{
    // the things in square brackets on top of classes are called attributes - there to add metadata to the thing they're sitting on top of
    // ASP.NetCore attributes will do certain things based on the presence of it
    // APIController means class needs to be exposed as HTTP API to internet
    // Route attribute means expose it at that endpoint specified in the string (below means api/values)
    [Route("api/values")]
    [ApiController]

    // when declaring class that inherits from ControllerBase and is Controller, the class is supposed  a thing and then Controller
    // ControllerBase can't return views
    public class ValuesController : ControllerBase
    {
        // GET api/values
        // make IEnumerable method accessible over internet using HttpGet
        [HttpGet]

        // IEnumerable accessible at internet over 'api/values' endpoint from Route attribute above
        public IEnumerable<string> Get()
        {
            // get json array data back and place in body
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // IActionResult exposed at api/values/5. '5' is not meaningful, just example. It is the id portion
        // {} denotes route parameter, similar to api/values/:id in react, but now it is api/values/{id}
        // no limits to how many parameters
        [HttpGet("{id}")]

        // use IActionResult to control specificity of Status Codes that come back (i.e., 200, 201, etc...), what headers need to come back, and body
        // ASP.Net will look for parameter with same name in url {id} and put it in method parameter with the same name (i.e, id below)
        // method signature still same: accessibiliity modifier, return type, name, parameter. Name should be specific on what it is doing
        // anything that is exposed to internet, needs to be public
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
