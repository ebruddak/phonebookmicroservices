using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Application.Dtos
{
    public class ReportDto
    {
        public string UUID { get; set; }
        public DateTime RequestTime { get;  set; }
        public DateTime CreatedTime { get;  set; }

        public bool Status { get;  set; }
        public string ReportUrl { get;  set; }

        public List<ReportItemDto>? ReportItems { get;  set; }
    }
}
