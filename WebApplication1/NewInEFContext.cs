using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApplication1.EFLog;
using WebApplication1.Models;

namespace WebApplication1
{
    public class NewInEFContext: DbContext
    {
        public NewInEFContext(DbContextOptions<NewInEFContext> options):base(options)
        {

        }

        public NewInEFContext()
        {

        }
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=.;Database=TestCode;User ID=sa;Password=123456;TrustServerCertificate=true");

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            options.UseLoggerFactory(loggerFactory);
            //敏感数据 也展示
            options.EnableSensitiveDataLogging(true);
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
               .Property<long>("PersonId");

            modelBuilder.Entity<Pet>()
                .Property<long>("PersonId");
        }

        
    }

    public static class LoggerSqlServer 
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder =>
            {
                #if DEBUG
                         builder.AddConsole();
                #endif
            });
    }
}
