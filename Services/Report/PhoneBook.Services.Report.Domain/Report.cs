using PhoneBook.Services.Report.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Domain
{
    public class Report:Entity,IAggregateRoot
    {
        public string UUID { get; set; }
        public DateTime RequestTime { get; private set; }
        public DateTime CreatedTime { get; private set; }

        public bool Status { get; private set; }
        public string ReportUrl { get; private set; }

        private readonly List<ReportItem> _reportItems;
        public IReadOnlyCollection<ReportItem> ReportItems => _reportItems;

        public Report()
        {
        }
        public Report( bool status,string reportUrl, DateTime createdTime)
        {
            _reportItems = new List<ReportItem>();
            RequestTime = DateTime.Now;
            Status = status;
            ReportUrl = reportUrl;
            CreatedTime = createdTime;
        }
        public void AddReportItem(string location, int personCount, int phoneNumberCount)
        {
       
                var newReportItem = new ReportItem(location, personCount, phoneNumberCount);
            _reportItems.Add(newReportItem);

        }
        public void UpdateReportStatus(bool status,string reportUrl)
        {
            Status = status;
            ReportUrl = reportUrl;
        }
    }
}
