using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsPerson.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string PersonCollectionName { get; set; }
        public string ContactInfoCollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
