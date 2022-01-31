using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PhoneBook.Services.MsPerson.Dtos;
using PhoneBook.Services.MsPerson.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Services.MsPerson
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var personService = serviceProvider.GetRequiredService<IPersonService>();

                if (!personService.GetAllAsync().Result.Data.Any())
                {
                    personService.CreateAsync(new PersonDto { Name = "Ebru",Surname="Dudak" , Company="Yd Yazılım"}).Wait();
                    personService.CreateAsync(new PersonDto { Name = "Ebruli", Surname = "Ebru", Company = "Unibim Bilisim" }).Wait();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
