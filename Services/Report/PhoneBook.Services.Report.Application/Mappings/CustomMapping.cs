using AutoMapper;
using PhoneBook.Services.Report.Application.Dtos;
using PhoneBook.Services.Report.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Application.Mappings
{
    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.Report, ReportDto>().ReverseMap();
            CreateMap<ReportItem, ReportItemDto>().ReverseMap();
        }
    }
}
