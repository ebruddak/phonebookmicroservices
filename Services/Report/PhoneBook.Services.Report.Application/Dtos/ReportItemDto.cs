using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Application.Dtos
{
    public class ReportItemDto
    {
        public string Location { get;  set; }
        public int PersonCount { get;  set; }
        public int PhoneNumberCount { get;  set; }
    }
}
