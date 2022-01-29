using AutoMapper;
using PhoneBook.Services.MsPerson.Dtos;
using PhoneBook.Services.MsPerson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsPerson.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonCreateDto>().ReverseMap();
            CreateMap<Person, PersonUpdateDto>().ReverseMap();

            CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoCreateDto>().ReverseMap();
            CreateMap<ContactInfo, ContactInfoUpdateDto>().ReverseMap();

            CreateMap<InfoType, InfoTypeDto>().ReverseMap();



        }
    }
}
