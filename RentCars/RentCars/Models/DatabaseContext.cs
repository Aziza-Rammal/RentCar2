using Microsoft.EntityFrameworkCore;
using RentCars.Models;

namespace RentCars.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rent> Rents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=Aziza\SQLEXPRESS;initial catalog=RentCarsDB;integrated security=SSPI;TrustServerCertificate=True;");
        }
    }
}
