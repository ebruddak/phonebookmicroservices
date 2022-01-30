using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.Report.Application.Commands;
using PhoneBook.Services.Report.Application.Queries;
using PhoneBook.Shared.ControllerBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddReportRequest(CreateReportCommand createReportCommand)
        {
            var response = await _mediator.Send(createReportCommand);

            return CreateActionResultInstance(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetReports()
        {
            var response = await _mediator.Send(new GetReportsQuery());

            return CreateActionResultInstance(response);
        }
    }
}
