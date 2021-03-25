﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Repository;

namespace PizzaBox.Repository.Migrations
{
    [DbContext(typeof(DatabaseCreationContext))]
    [Migration("20210324235559_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Property<Guid>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaxPizzas")
                        .HasColumnType("int");

                    b.Property<int>("MaxPrice")
                        .HasColumnType("int");

                    b.Property<int>("MaxToppings")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Crust", b =>
                {
                    b.Property<Guid>("CompID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AStoreStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CheeseStuffed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StuffedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CompID");

                    b.HasIndex("AStoreStoreID");

                    b.ToTable("Crust");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Size", b =>
                {
                    b.Property<Guid>("CompID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AStoreStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CompID");

                    b.HasIndex("AStoreStoreID");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Topping", b =>
                {
                    b.Property<Guid>("CompID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AStoreStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BasicPizzaPresetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CompID");

                    b.HasIndex("AStoreStoreID");

                    b.HasIndex("BasicPizzaPresetID");

                    b.ToTable("Topping");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.BasicPizza", b =>
                {
                    b.Property<Guid>("PresetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CrustCompID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PizzaPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SizeCompID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PresetID");

                    b.HasIndex("CrustCompID");

                    b.HasIndex("OrderID");

                    b.HasIndex("SizeCompID");

                    b.ToTable("BasicPizza");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BasicPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LastStoreStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastTimeOrdered")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.HasIndex("LastStoreStoreID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CurTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StoreID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PresetPizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Models.BasicPizza");

                    b.Property<Guid?>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("StoreID");

                    b.HasDiscriminator().HasValue("PresetPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Crust", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", null)
                        .WithMany("CrustList")
                        .HasForeignKey("AStoreStoreID");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Size", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", null)
                        .WithMany("SizeList")
                        .HasForeignKey("AStoreStoreID");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Topping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", null)
                        .WithMany("ToppingsList")
                        .HasForeignKey("AStoreStoreID");

                    b.HasOne("PizzaBox.Domain.Models.BasicPizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("BasicPizzaPresetID");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.BasicPizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustCompID");

                    b.HasOne("PizzaBox.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderID");

                    b.HasOne("PizzaBox.Domain.Abstracts.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeCompID");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "LastStore")
                        .WithMany()
                        .HasForeignKey("LastStoreStoreID");

                    b.Navigation("LastStore");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Customer", "Cust")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID");

                    b.Navigation("Cust");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.PresetPizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "store")
                        .WithMany("PresetPizzas")
                        .HasForeignKey("StoreID");

                    b.Navigation("store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Navigation("CrustList");

                    b.Navigation("PresetPizzas");

                    b.Navigation("SizeList");

                    b.Navigation("ToppingsList");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.BasicPizza", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
