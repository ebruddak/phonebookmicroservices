using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Services.Report.Application.Commands;
using PhoneBook.Services.Report.Application.Queries;
using PhoneBook.Shared.ControllerBases;
using PhoneBook.Shared.Messages;
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
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public ReportsController(IMediator mediator, ISendEndpointProvider sendEndpointProvider)
        {
            _mediator = mediator;
            _sendEndpointProvider = sendEndpointProvider;
        }
        [Route("/api/[controller]/AddReport")]
        [HttpPost]
        public async Task<IActionResult> AddReportRequest(CreateReportCommand createReportCommand)
        {
            var response = await _mediator.Send(createReportCommand);

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:report-request-service"));
            var createReportRequestMessageCommand = new CreateReportRequestMessageCommand();
            createReportRequestMessageCommand.RequestTime = createReportCommand.RequestTime;
            createReportRequestMessageCommand.ReportUrl = createReportCommand.ReportUrl;
            createReportRequestMessageCommand.Status = createReportCommand.Status;
            createReportRequestMessageCommand.UUID = response.Data.Id.ToString()
                ;
            await sendEndpoint.Send<CreateReportRequestMessageCommand>(createReportRequestMessageCommand);

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
