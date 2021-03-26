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
    [Migration("20210326032736_InitTest2")]
    partial class InitTest2
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
                    b.Property<Guid>("CrustID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CheeseStuffed")
                        .HasColumnType("bit");

                    b.Property<Guid>("CompID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StuffedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrustID", "StoreID");

                    b.HasIndex("StoreID");

                    b.ToTable("Crust");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Size", b =>
                {
                    b.Property<Guid>("SizeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SizeID", "StoreID");

                    b.HasIndex("StoreID");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Topping", b =>
                {
                    b.Property<Guid>("ToppingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BasicPizzaPresetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToppingID", "StoreID");

                    b.HasIndex("BasicPizzaPresetID");

                    b.HasIndex("StoreID");

                    b.ToTable("Topping");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.BasicPizza", b =>
                {
                    b.Property<Guid>("PresetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CrustID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CrustStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PizzaPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SizeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SizeStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PresetID");

                    b.HasIndex("OrderID");

                    b.HasIndex("CrustID", "CrustStoreID");

                    b.HasIndex("SizeID", "SizeStoreID");

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

                    b.Property<Guid?>("StoreMangerStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerID");

                    b.HasIndex("LastStoreStoreID");

                    b.HasIndex("StoreMangerStoreID");

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
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Size", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", null)
                        .WithMany("SizeList")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Topping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.BasicPizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("BasicPizzaPresetID");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", null)
                        .WithMany("ToppingsList")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.BasicPizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderID");

                    b.HasOne("PizzaBox.Domain.Abstracts.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustID", "CrustStoreID");

                    b.HasOne("PizzaBox.Domain.Abstracts.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeID", "SizeStoreID");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "LastStore")
                        .WithMany()
                        .HasForeignKey("LastStoreStoreID");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "StoreManger")
                        .WithMany()
                        .HasForeignKey("StoreMangerStoreID");

                    b.Navigation("LastStore");

                    b.Navigation("StoreManger");
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
