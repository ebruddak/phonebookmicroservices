using MassTransit;
using PhoneBook.Services.Report.Infrastructure;
using PhoneBook.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Application.Consumers
{
    public class CreateReportRequestMessageCommandConsumer : IConsumer<CreateReportRequestMessageCommand>
    {
        private readonly ReportDbContext _reportsDbContext;

        public CreateReportRequestMessageCommandConsumer(ReportDbContext reportsDbContext)
        {
            _reportsDbContext = reportsDbContext;
        }

        public async Task Consume(ConsumeContext<CreateReportRequestMessageCommand> context)
        {
            //Person ms ile haberleşilecek

            var report = _reportsDbContext.Reports.FindAsync(context.Message.UUID).Result;
            report.Status = true;
            report.CreatedTime = DateTime.Now;
            report.ReportUrl = "PhoneBookReport" + report.CreatedTime + ".xlsx";
             _reportsDbContext.Reports.Update(report);
        }
    }
}
