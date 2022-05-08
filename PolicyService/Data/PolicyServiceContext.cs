using Microsoft.EntityFrameworkCore;
using PolicyService.Data.Entities;

namespace PolicyService.Data
{
    public class PolicyServiceContext : DbContext
    {
        public PolicyServiceContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyMaster>().HasKey(p =>p.Id);
            modelBuilder.Entity<ConsumerPolicy>().HasKey(p => p.Id);

           
            modelBuilder.Entity<ConsumerPolicy>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<PolicyMaster>().HasData(
                new PolicyMaster()
                {
                    Id = "P01",
                    AssuredSum= 400000,
                    BaseLocation= "Chennai",
                    BusinessValue=8,
                    ConsumerType= "Owner",
                    PropertyType= "Building",
                    PropertyValue=5,
                    Tenure="3 year",
                    Type= "Replacement"
                },
                 new PolicyMaster()
                 {
                     Id = "P02",
                     AssuredSum = 20000000,
                     BaseLocation = "Chennai",
                     BusinessValue = 9,
                     ConsumerType = "Owner",
                     PropertyType = "Factory Equipment",
                     PropertyValue = 10,
                     Tenure = "1 year",
                     Type = "Replacement"
                 },
                  new PolicyMaster()
                  {
                      Id = "P03",
                      AssuredSum = 200000,
                      BaseLocation = "Pune",
                      BusinessValue = 7,
                      ConsumerType = "Owner",
                      PropertyType = "Property in Transit",
                      PropertyValue = 8,
                      Tenure = "1 week",
                      Type = "Pay Back"
                  }
                  
                );
           base.OnModelCreating(modelBuilder);
        }

        public DbSet<PolicyMaster> PolicyMasters { get; set; }
        public DbSet<ConsumerPolicy> ConsumerPolicies { get; set; }
    }
}
