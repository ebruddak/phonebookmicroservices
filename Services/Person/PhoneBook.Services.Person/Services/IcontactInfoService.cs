using PhoneBook.Services.MsPerson.Dtos;
using PhoneBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsPerson.Services
{
    public interface IContactInfoService
    {
        Task<Response<List<ContactInfoDto>>> GetAllAsync();

        Task<Response<ContactInfoDto>> GetByIdAsync(string id);

        Task<Response<List<ContactInfoDto>>> GetAllByUserIdAsync(string userId);

        Task<Response<ContactInfoDto>> CreateAsync(ContactInfoCreateDto contactInfoCreateDto);

        Task<Response<NoContent>> UpdateAsync(ContactInfoUpdateDto contactInfoUpdateDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
