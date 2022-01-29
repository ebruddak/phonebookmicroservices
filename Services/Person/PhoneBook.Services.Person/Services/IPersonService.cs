using PhoneBook.Services.MsPerson.Dtos;
using PhoneBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsPerson.Services
{
    public interface IPersonService
    {
        Task<Response<List<PersonDto>>> GetAllAsync();

        Task<Response<PersonDto>> CreateAsync(PersonDto category);

        Task<Response<PersonDto>> GetByIdAsync(string id);
    }
}
