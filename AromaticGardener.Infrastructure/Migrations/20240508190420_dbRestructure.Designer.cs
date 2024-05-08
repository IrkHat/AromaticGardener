﻿// <auto-generated />
using AromaticGardener.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AromaticGardener.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240508190420_dbRestructure")]
    partial class dbRestructure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AromaticGardener.Domain.Entities.GrowthHabit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Habit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GrowthHabits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Habit = "Herb"
                        },
                        new
                        {
                            Id = 2,
                            Habit = "Shrub"
                        },
                        new
                        {
                            Id = 3,
                            Habit = "Tree"
                        },
                        new
                        {
                            Id = 4,
                            Habit = "Vine"
                        });
                });

            modelBuilder.Entity("AromaticGardener.Domain.Entities.Herb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BestSoilType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bloom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CommonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GrowthHabitId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insulation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LifeCycleId")
                        .HasColumnType("int");

                    b.Property<string>("ScientificName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SoilPhMax")
                        .HasColumnType("float");

                    b.Property<double>("SoilPhMin")
                        .HasColumnType("float");

                    b.Property<string>("Watering")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrowthHabitId");

                    b.HasIndex("LifeCycleId");

                    b.ToTable("Herbs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BestSoilType = "Well-drained soil",
                            Bloom = "Summer",
                            CommonName = "Oregano",
                            Description = "Perennial herbaceous plant of the mint family, characterized by opposite, aromatic leaves and purple flowers.",
                            GrowthHabitId = 1,
                            ImageUrl = "",
                            Insulation = "Full",
                            LifeCycleId = 1,
                            ScientificName = "Origanum Vulgare",
                            SoilPhMax = 7.0,
                            SoilPhMin = 6.5,
                            Watering = "Water when topsoil is dry"
                        });
                });

            modelBuilder.Entity("AromaticGardener.Domain.Entities.LifeCycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cycle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LifeCycles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cycle = "Annual"
                        },
                        new
                        {
                            Id = 2,
                            Cycle = "Biennial"
                        },
                        new
                        {
                            Id = 3,
                            Cycle = "Perennial"
                        });
                });

            modelBuilder.Entity("AromaticGardener.Domain.Entities.Herb", b =>
                {
                    b.HasOne("AromaticGardener.Domain.Entities.GrowthHabit", "GrowthHabit")
                        .WithMany()
                        .HasForeignKey("GrowthHabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AromaticGardener.Domain.Entities.LifeCycle", "LifeCycle")
                        .WithMany()
                        .HasForeignKey("LifeCycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrowthHabit");

                    b.Navigation("LifeCycle");
                });
#pragma warning restore 612, 618
        }
    }
}
