using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsPerson.Dtos
{
    public class ContactInfoCreateDto
    {
        public string PersonID { get; set; }
        public InfoTypeDto Type { get; set; }
        public string Content { get; set; }
    }
}
