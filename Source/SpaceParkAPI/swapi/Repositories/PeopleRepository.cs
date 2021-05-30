using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.SWAPI;
using SpaceParkAPI.SWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.swapi.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        //public async Task<List<Person>> GetAllPersons()
        //{
        //    return await Fetch.People();
        //}

        public async Task<List<Person>> GetAllPersons()
        {
            return await Fetch.People();
        }


        public async Task<Person> GetPerson(string name)
        {
            return (await Fetch.People(name)).FirstOrDefault();
        }
    }
}
