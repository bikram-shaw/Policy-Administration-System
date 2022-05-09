using Microsoft.EntityFrameworkCore;
using QuotesService.Data.Entities;

namespace QuotesService.Data
{
    public class QuotesServiceContext : DbContext
    {
        public QuotesServiceContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuotesMaster>().HasKey(x => x.Id);
            modelBuilder.Entity<QuotesMaster>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<QuotesMaster>().HasData(
                new QuotesMaster()
                {
                    Id = 1,
                    BusinessValue =10,
                    PropertyType = "Inventory",
                    PropertyValue =5,
                    Quotes="30000"
                    
                },
                 new QuotesMaster()
                 {
                     Id = 2,
                     BusinessValue = 7,
                     PropertyType = "Equipment",
                     PropertyValue = 10,
                     Quotes = "45000"

                 },
                  new QuotesMaster()
                  {
                      Id = 3,
                      BusinessValue = 5,
                      PropertyType = "Equipment",
                      PropertyValue = 8,
                      Quotes = "80000"

                  }

                );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<QuotesMaster> QuotesMaster { get; set; }

    }
}
