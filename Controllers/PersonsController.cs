﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ExRam.Gremlinq.Core;

namespace gremlinq_aspnet
{
    [ApiController]
    [Route("/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IGremlinQuerySource _g;

        public PersonsController(IGremlinQuerySource g)
        {
            _g = g;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => Ok(await _g
                 .V<Person>()
                 .ToArrayAsync());

        [HttpGet("petMaps")]
        public async Task<IActionResult> PetMaps() => Ok(await _g
            .V<Person>()
            .Project(b => b
                .ToDynamic()
                .By("Person", __ => __)
                .By("Pets", __ => __
                    .Out<Owns>()
                    .OfType<Pet>()
                    .Fold()))
            .ToArrayAsync());

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromQuery] string name, [FromQuery] int age) => Ok(await _g
            .AddV(new Person { Name = name, Age = age })
            .FirstAsync());
    }
}
