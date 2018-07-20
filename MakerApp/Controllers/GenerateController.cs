using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MakerApp.Controllers
{
    [Route("[action]")]
    public class GenerateController : Controller
    {
        [HttpGet]
        public IActionResult Names() => Ok(Generate(10, (faker) => faker.Name.FullName()));

        [HttpGet]
        public IActionResult Address() => Ok(Generate(10, (faker) => faker.Address.FullAddress()));

        [HttpGet]
        public IActionResult Product() => Ok(Generate(10, (faker) => faker.Commerce.Product()));

        [HttpGet]
        public IActionResult Company() => Ok(Generate(10, (faker) => faker.Company.CompanyName()));

        [HttpGet]
        public IActionResult Email() => Ok(Generate(10, (faker) => faker.Internet.Email()));



        private IEnumerable<string> Generate(int count, Func<Faker, string> generator)
        {
            var faker = new Faker();
            return Enumerable.Range(1, 10).Select(_ => generator(faker));
        }




    }
}
