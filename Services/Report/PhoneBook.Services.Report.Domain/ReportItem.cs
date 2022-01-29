using PhoneBook.Services.Report.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Domain
{
    public class ReportItem:Entity
    {
        public string Location { get; private set; }
        public int PersonCount { get; private set; }
        public int PhoneNumberCount { get; private set; }

        public ReportItem(string location, int personCount, int phoneNumberCount)
        {
            Location = location;
            PersonCount = personCount;
            PhoneNumberCount = phoneNumberCount;
        }
    }
}
