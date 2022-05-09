﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuotesService.Data;

namespace QuotesService.Data.Migrations
{
    [DbContext(typeof(QuotesServiceContext))]
    partial class QuotesServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuotesService.Data.Entities.QuotesMaster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BusinessValue")
                        .HasColumnType("bigint");

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PropertyValue")
                        .HasColumnType("bigint");

                    b.Property<string>("Quotes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuotesMaster");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BusinessValue = 10L,
                            PropertyType = "Inventory",
                            PropertyValue = 5L,
                            Quotes = "30000"
                        },
                        new
                        {
                            Id = 2L,
                            BusinessValue = 7L,
                            PropertyType = "Equipment",
                            PropertyValue = 10L,
                            Quotes = "45000"
                        },
                        new
                        {
                            Id = 3L,
                            BusinessValue = 5L,
                            PropertyType = "Equipment",
                            PropertyValue = 8L,
                            Quotes = "80000"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
