﻿// <auto-generated />
using System;
using ConsumerService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsumerService.Data.Migrations
{
    [DbContext(typeof(ConsumerBusinessContext))]
    partial class ConsumerBusinessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsumerService.Data.Entities.BusinessDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BusinessAge")
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("BusinessTurnOver")
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("BusinessValue")
                        .HasColumnType("bigint");

                    b.Property<long>("CapitalInvested")
                        .HasColumnType("bigint");

                    b.Property<long>("ConsumerId")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalEmployee")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId")
                        .IsUnique();

                    b.ToTable("BusinessDetails");
                });

            modelBuilder.Entity("ConsumerService.Data.Entities.BusinessMaster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BusinessAge")
                        .HasColumnType("bigint");

                    b.Property<string>("BusinessCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TotalEmployee")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("BusinessMasters");
                });

            modelBuilder.Entity("ConsumerService.Data.Entities.ConsumerDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgentId")
                        .HasColumnType("int");

                    b.Property<string>("AgentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PanDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConsumerDetails");
                });

            modelBuilder.Entity("ConsumerService.Data.Entities.PropertyDetails", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BuildingAge")
                        .HasColumnType("bigint");

                    b.Property<string>("BuildingSqft")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingStoreys")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("BusinessId")
                        .HasColumnType("bigint");

                    b.Property<long>("CostoftheAsset")
                        .HasColumnType("bigint");

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PropertyValue")
                        .HasColumnType("bigint");

                    b.Property<long>("SalvageValue")
                        .HasColumnType("bigint");

                    b.Property<long>("UseFulLifeOfTheAsset")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("ConsumerService.Data.Entities.PropertyMaster", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BuildingAge")
                        .HasColumnType("bigint");

                    b.Property<string>("BuildingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PropertyMasters");
                });

            modelBuilder.Entity("ConsumerService.Data.Entities.BusinessDetails", b =>
                {
                    b.HasOne("ConsumerService.Data.Entities.ConsumerDetails", "ConsumerDetails")
                        .WithOne("BusinessDetails")
                        .HasForeignKey("ConsumerService.Data.Entities.BusinessDetails", "ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumerDetails");
                });

            modelBuilder.Entity("ConsumerService.Data.Entities.PropertyDetails", b =>
                {
                    b.HasOne("ConsumerService.Data.Entities.BusinessDetails", "BusinessDetails")
                        .WithMany("Properties")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessDetails");
                });

            modelBuilder.Entity("ConsumerService.Data.Entities.BusinessDetails", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("ConsumerService.Data.Entities.ConsumerDetails", b =>
                {
                    b.Navigation("BusinessDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
