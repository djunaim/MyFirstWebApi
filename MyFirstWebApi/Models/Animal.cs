using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// models are contrainer for information
namespace MyFirstWebApi.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
