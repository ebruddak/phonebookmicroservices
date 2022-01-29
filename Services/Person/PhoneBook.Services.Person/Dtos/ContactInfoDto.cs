using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Dtos
{
    public class ContactInfoDto
    {
      
        public string PersonID { get; set; }

        public InfoTypeDto Type { get; set; }
        public string Content { get; set; }
    }
}
