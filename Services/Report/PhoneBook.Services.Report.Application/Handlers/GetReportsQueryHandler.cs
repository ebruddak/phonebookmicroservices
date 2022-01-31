using AutoMapper.Internal.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.Report.Application.Dtos;
using PhoneBook.Services.Report.Application.Mappings;
using PhoneBook.Services.Report.Application.Queries;
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
    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, Response<List<ReportDto>>>
    {
        private readonly ReportDbContext _context;

        public GetReportsQueryHandler(ReportDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<ReportDto>>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Reports.ToListAsync();

            if (!orders.Any())
            {
                return Response<List<ReportDto>>.Success(new List<ReportDto>(), 200);
            }

            var reportDto = ObjectMapper.Mapper.Map<List<ReportDto>>(orders);

            return Response<List<ReportDto>>.Success(reportDto, 200);
        }
    }
}
