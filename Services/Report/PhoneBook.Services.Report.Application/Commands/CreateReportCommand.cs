using MediatR;
using PhoneBook.Services.Report.Application.Dtos;
using PhoneBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Application.Commands
{
    public class CreateReportCommand : IRequest<Response<CreatedReportDto>>
    {

        public DateTime CreatedTime { get; set; }

        public bool Status { get; set; }
        public string ReportUrl { get; set; }
        public List<ReportItemDto> ReportItems { get; set; }

    }
}
