using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models;

namespace MyFirstWebApi.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        // created field of animals to be used in multiple methods
        // every time doing GET request, a new List gets instantiated so would get 3 in a list every time
        // if mark List as static, will only get instantiated 1 time. 1 instance of list will be shared across all instances of AnimalsController class AKA use same List<Animal>
        static List<Animal> _animals = new List<Animal>
                                    {
                                        new Animal {Id = 1, Name = "Steve", Type = "Elephant", Weight = 2000},
                                        new Animal {Id = 2, Name = "George", Type = "Monkey", Weight = 87},
                                        new Animal {Id = 3, Name = "Tony", Type = "Tiger", Weight = 1200},
                                    };

        // GET /api/animals
        // make it accessible over get and whatever is our base route (i.e., api/animals)
        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            // returning a collection of animals and translating c# classes to json data
            return Ok(_animals);
        }

        // GET /api/animals/{id}
        // adding url id segment that is dynamically populated and inserted to same paramter in method called id
        [HttpGet("{id}")]
        public IActionResult GetSingleAnimal(int id)
        {
            // look at list of animals and find me first thing from list where animal's id matches id parameter
            // FirstOrDefault will give the first or default
            var animalIWant = _animals.FirstOrDefault(a => a.Id == id);

            // below code will handle exception if id was not found
            if (animalIWant == null)
            {
                return NotFound($"Animal with the id {id} was not found.");
            }
            return Ok(animalIWant);
        }

        // POST /api/animals
        // expecting post http request. If don't specify in parentheses, will use base route (i.e., /api/animals)
        // expect body of request be Animal
        [HttpPost]

        // parameters on post accept body to be 
        public IActionResult AddAnAnimal(Animal animalToAdd)
        {
            _animals.Add(animalToAdd);
            return Ok(_animals);
        }

        // PUT /api/animals/{id}
        // PUT are for updates for things that already exist
        [HttpPut("{id}")]

        // id will come from url and Animal object come from request body
        public IActionResult UpdateAnAnimal(int id, Animal animal)
        {
            var animalToUpdate = _animals.FirstOrDefault(a => a.Id == id);
            if (animalToUpdate == null)
            {
                return NotFound("Can't update cause it doesn't exist");
            }

            animalToUpdate.Name = animal.Name;
            animalToUpdate.Weight = animal.Weight;
            animalToUpdate.Type = animal.Type;

            return Ok(animalToUpdate);
        }
    }
}