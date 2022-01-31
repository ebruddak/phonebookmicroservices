using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PhoneBook.Services.Report.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;
using MassTransit;
using PhoneBook.Services.Report.Application.Consumers;

namespace PhoneBook.Services.MsReport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {

                x.AddConsumer<CreateReportRequestMessageCommandConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration["RabbitMQUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("report-request-service", e =>
                    {
                        e.ConfigureConsumer<CreateReportRequestMessageCommandConsumer>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();

            services.AddDbContext<ReportDbContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("PostgreSql"), configure =>
                {
                    configure.MigrationsAssembly("PhoneBook.Services.Report.Infrastructure");
                });
            });
            services.AddMediatR(typeof(Report.Application.Handlers.CreateReportCommandHandler).Assembly);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook.Services.MsReport", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ReportDbContext context)
        {

            if (env.IsDevelopment())
            {
                context.Database.EnsureCreated();

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook.Services.MsReport v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
