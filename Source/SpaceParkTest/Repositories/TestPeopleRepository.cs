using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.swapi.Repositories;
using SpaceParkAPI.SWAPI.Models;

namespace SpaceParkTest.Repositories
{
    class TestPeopleRepository : IPeopleRepository
    {
        public List<Person> People { get; set; }

        public TestPeopleRepository(List<Person> people)
        {
            People = people ?? new List<Person>();
        }

        public Task<List<Person>> GetAllPersons()
        {
            return Task.FromResult(People);
        }

        public Task<Person> GetPerson(string name)
        {
            return Task.FromResult(People.SingleOrDefault(p => p.Name == name));
        }
    }
}
