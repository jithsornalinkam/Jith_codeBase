﻿// <auto-generated />
using System;
using ApplicationTracker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationTracker.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationTracker.Models.Application", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateApplied")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Applications");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CompanyName = "Alpha",
                            DateApplied = new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Senior Developer",
                            Status = "Progress"
                        },
                        new
                        {
                            ID = 2,
                            CompanyName = "Beta",
                            DateApplied = new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Developer",
                            Status = "Progress"
                        },
                        new
                        {
                            ID = 3,
                            CompanyName = "Beta",
                            DateApplied = new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Position = "Developer",
                            Status = "Rejected"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
