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
                    BusinessValue =0,
                    PropertyType = "",
                    PropertyValue =0,
                    Quotes=""
                    
                },
                 new QuotesMaster()
                 {
                     Id = 2,
                     BusinessValue = 0,
                     PropertyType = "",
                     PropertyValue = 0,
                     Quotes = ""

                 },
                  new QuotesMaster()
                  {
                      Id = 3,
                      BusinessValue = 0,
                      PropertyType = "",
                      PropertyValue = 0,
                      Quotes = ""

                  },
                   new QuotesMaster()
                   {
                       Id = 4,
                       BusinessValue = 0,
                       PropertyType = "",
                       PropertyValue = 0,
                       Quotes = ""

                   }

                );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<QuotesMaster> QuotesMaster { get; set; }

    }
}
