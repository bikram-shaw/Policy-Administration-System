using ConsumerService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsumerService.Data
{
    public class ConsumerBusinessContext : DbContext
    {


        public ConsumerBusinessContext(DbContextOptions<ConsumerBusinessContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessDetails>().HasKey(x => x.Id); 
            modelBuilder.Entity<BusinessMaster>().HasKey(x => x.Id);
            modelBuilder.Entity<ConsumerDetails>().HasKey(x => x.Id);
            modelBuilder.Entity<PropertyDetails>().HasKey(x => x.Id);
            modelBuilder.Entity<PropertyMaster>().HasKey(x => x.Id);

            modelBuilder.Entity<BusinessDetails>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<BusinessMaster>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ConsumerDetails>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PropertyDetails>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PropertyMaster>().Property(x => x.Id).ValueGeneratedOnAdd();

        

            //configure consumer to business relationship
            modelBuilder.Entity<ConsumerDetails>()
                .HasOne(c => c.BusinessDetails)
                .WithOne(b=>b.ConsumerDetails)
                .HasForeignKey<BusinessDetails>(b => b.ConsumerId);

            //configure business to property relationship
            modelBuilder.Entity<PropertyDetails>()
                .HasOne(p=>p.BusinessDetails)
                .WithMany(b=>b.Properties)
                .HasForeignKey(p=>p.BusinessId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BusinessDetails> BusinessDetails { get; set; }
        public DbSet<BusinessMaster> BusinessMasters { get; set; }
        public DbSet<ConsumerDetails> ConsumerDetails { get; set; }
        public DbSet<PropertyDetails> PropertyDetails { get; set; }
        public DbSet<PropertyMaster> PropertyMasters { get; set; }
    }
}
