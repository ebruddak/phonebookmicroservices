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
    public class ContactInfosController : CustomBaseController
    {
        private readonly IContactInfoService _ContactInfoservice;

        public ContactInfosController(IContactInfoService ContactInfoservice)
        {
            _ContactInfoservice = ContactInfoservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _ContactInfoservice.GetAllAsync();

            return CreateActionResultInstance(response);
        }

        //ContactInfos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _ContactInfoservice.GetByIdAsync(id);

            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _ContactInfoservice.GetAllByUserIdAsync(userId);

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactInfoCreateDto ContactInfoCreateDto)
        {
            var response = await _ContactInfoservice.CreateAsync(ContactInfoCreateDto);

            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ContactInfoUpdateDto ContactInfoUpdateDto)
        {
            var response = await _ContactInfoservice.UpdateAsync(ContactInfoUpdateDto);

            return CreateActionResultInstance(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _ContactInfoservice.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
