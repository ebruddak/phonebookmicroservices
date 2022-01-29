using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.MsPerson.Dtos;
using PhoneBook.Services.MsPerson.Services;
using PhoneBook.Shared.ControllerBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : CustomBaseController
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService PersonService)
        {
            _personService = PersonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Persons = await _personService.GetAllAsync();

            return CreateActionResultInstance(Persons);
        }

        //Persons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var Person = await _personService.GetByIdAsync(id);

            return CreateActionResultInstance(Person);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDto PersonDto)
        {
            var response = await _personService.CreateAsync(PersonDto);

            return CreateActionResultInstance(response);
        }
    }
}
