using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingExample.Models
{
    public class Repository
    {
        public List<Country> Countries { get; set; }
        public List<State> States { get; set; }

        public Repository()
        {
            Countries = new List<Country>()
            {
                new Country{ Id = 1,Name="A"},
                new Country { Id = 2, Name = "B" }
            };

            States = new List<State>()
            {
                new State{Id= 1, Name = "A1",CountryId = 1},
                new State{Id= 2, Name = "B1",CountryId = 2},
                new State{Id= 3, Name = "A2",CountryId = 1},
                new State{Id= 4, Name = "B2",CountryId = 2},
                new State{Id= 5, Name = "A3",CountryId = 1},
                new State{Id= 6, Name = "B3",CountryId = 2},
                new State{Id= 7, Name = "A4",CountryId = 1},
                new State{Id= 8, Name = "A5",CountryId = 1},
                new State{Id= 9, Name = "B4",CountryId = 2},
                new State{Id= 10, Name = "A6",CountryId = 1}
            };
        }


    }
}
