﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ADO.NET_HW_03_10.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241008094344_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 100,
                            Name = "Crystal Soda",
                            Price = 2.99m
                        },
                        new
                        {
                            Id = 2,
                            Count = 50,
                            Name = "Starberry Juice",
                            Price = 3.49m
                        },
                        new
                        {
                            Id = 3,
                            Count = 75,
                            Name = "Shadow Coffee",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 4,
                            Count = 120,
                            Name = "Moonlight Tea",
                            Price = 4.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
