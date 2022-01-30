using MediatR;
using PhoneBook.Services.Report.Application.Commands;
using PhoneBook.Services.Report.Application.Dtos;
using PhoneBook.Services.Report.Infrastructure;
using PhoneBook.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Application.Handlers
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, Response<CreatedReportDto>>
    {
        private readonly ReportDbContext _context;

        public CreateReportCommandHandler(ReportDbContext context)
        {
            _context = context;
        }


        public async Task<Response<CreatedReportDto>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
         
            Domain.Report newReport = new Domain.Report(request.Status, request.ReportUrl,request.RequestTime);


            request.ReportItems.ForEach(x =>
            {
                newReport.AddReportItem(x.Location, x.PersonCount, x.PhoneNumberCount);
            });

            await _context.Reports.AddAsync(newReport);

            await _context.SaveChangesAsync();

            return Response<CreatedReportDto>.Success(new CreatedReportDto { Id = newReport.Id }, 200);
        }
    }
}
