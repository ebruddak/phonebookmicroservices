using Microsoft.EntityFrameworkCore;
using PhoneBook.Services.Report.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Infrastructure
{
    public class ReportDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "reporting";

        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Report> Reports { get; set; }
        public DbSet<ReportItem> ReportItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Report>().ToTable("Reports", DEFAULT_SCHEMA);
            modelBuilder.Entity<ReportItem>().ToTable("ReportItems", DEFAULT_SCHEMA);

            base.OnModelCreating(modelBuilder);
        }
    }
}
