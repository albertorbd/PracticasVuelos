using Microsoft.EntityFrameworkCore;
using Practices.Models;
using Microsoft.Extensions.Logging;

namespace Practices.Data
{
    public class PracticesContext : DbContext
    {

        public PracticesContext(DbContextOptions<PracticesContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Mario", Email = "mario@gmail.com", Password = "mario12345", Phone = "4574", DNI = "32452464D" },
                new User { Id = 2, Name = "Carlos", Email = "carlos@gmail.com", Password = "carlos12345", Phone = "4567477", DNI = "23523562D" },
                new User { Id = 3, Name = "Fernando", Email = "fernando@gmail.com", Password = "fernando12345", Phone = "4745", DNI = "23526445X" },
                new User { Id = 4, Name = "Eduardo", Email = "eduardo@gmail.com", Password = "eduardo12345", Phone = "4574548", DNI = "52353425D" }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Ryanair", Password = "ryanair12345", FoundationDate = new DateTime(2022, 1, 3, 13, 54, 18), EmployeeCount = "100", Website = true },
                new Company { Id = 2, Name = "Vueling", Password = "vueling12345", FoundationDate = new DateTime(2021, 1, 3, 13, 54, 48), EmployeeCount = "50", Website = false }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, UserId = 1, CompanyId = 1, Origin = "España", Destination = "Japón", DepartureDate = new DateTime(2023, 1, 3, 13, 54, 48), ReturnDate = new DateTime(2024, 1, 3, 13, 54, 48), Amount = 90 },
                new Booking { Id = 2, UserId = 1, CompanyId = 2, Origin = "España", Destination = "EEUU", DepartureDate = new DateTime(2023, 1, 3, 13, 54, 48), ReturnDate = new DateTime(2024, 1, 3, 13, 54, 48), Amount = 70 },
                new Booking { Id = 3, UserId = 2, CompanyId = 1, Origin = "Argentina", Destination = "Islas Canarias", DepartureDate = new DateTime(2023, 1, 3, 13, 54, 48), ReturnDate = new DateTime(2024, 1, 3, 13, 54, 48), Amount = 30 }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging(); // Opcional
        }
    }
}
