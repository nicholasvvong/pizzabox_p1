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
    [Migration("20210328182513_Final5")]
    partial class Final5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizzaComponent", b =>
                {
                    b.Property<Guid>("CompID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ITypeTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CompID");

                    b.HasIndex("ITypeTypeID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Comps");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Property<Guid>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MaxPizzas")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxPrice")
                        .HasColumnType("decimal(18,2)");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CheeseStuffed")
                        .HasColumnType("bit");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<Guid?>("PizzaTypeCompID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("StuffedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CrustID");

                    b.HasIndex("PizzaTypeCompID");

                    b.HasIndex("StoreID");

                    b.ToTable("Crusts");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Size", b =>
                {
                    b.Property<Guid>("SizeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<Guid?>("PizzaTypeCompID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SizeID");

                    b.HasIndex("PizzaTypeCompID");

                    b.HasIndex("StoreID");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Topping", b =>
                {
                    b.Property<Guid>("ToppingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<Guid?>("PizzaTypeCompID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("StoreID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ToppingID");

                    b.HasIndex("PizzaTypeCompID");

                    b.HasIndex("StoreID");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.BasicPizza", b =>
                {
                    b.Property<Guid>("PresetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AStoreStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CrustID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PizzaPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SizeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PresetID");

                    b.HasIndex("AStoreStoreID");

                    b.HasIndex("CrustID");

                    b.HasIndex("OrderID");

                    b.HasIndex("SizeID");

                    b.ToTable("BasicPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LastStoreStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastTimeOrdered")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StoreMangerStoreID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomerID");

                    b.HasIndex("LastStoreStoreID");

                    b.HasIndex("StoreMangerStoreID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.ItemType", b =>
                {
                    b.Property<Guid>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TypeID");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ItemType");
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
                    b.Property<Guid>("BasicPizzaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ToppingID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BasicPizzaID", "ToppingID");

                    b.HasIndex("ToppingID");

                    b.ToTable("PresetPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizzaComponent", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.ItemType", "IType")
                        .WithMany()
                        .HasForeignKey("ITypeTypeID");

                    b.Navigation("IType");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Crust", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizzaComponent", "PizzaType")
                        .WithMany()
                        .HasForeignKey("PizzaTypeCompID");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                        .WithMany("CrustList")
                        .HasForeignKey("StoreID");

                    b.Navigation("PizzaType");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Size", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizzaComponent", "PizzaType")
                        .WithMany()
                        .HasForeignKey("PizzaTypeCompID");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                        .WithMany("SizeList")
                        .HasForeignKey("StoreID");

                    b.Navigation("PizzaType");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Topping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizzaComponent", "PizzaType")
                        .WithMany()
                        .HasForeignKey("PizzaTypeCompID");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                        .WithMany("ToppingsList")
                        .HasForeignKey("StoreID");

                    b.Navigation("PizzaType");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.BasicPizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", null)
                        .WithMany("PresetPizzas")
                        .HasForeignKey("AStoreStoreID");

                    b.HasOne("PizzaBox.Domain.Abstracts.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustID");

                    b.HasOne("PizzaBox.Domain.Models.Order", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("OrderID");

                    b.HasOne("PizzaBox.Domain.Abstracts.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeID");

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
                    b.HasOne("PizzaBox.Domain.Models.BasicPizza", "BasicPizza")
                        .WithMany("PresetPizzas")
                        .HasForeignKey("BasicPizzaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Abstracts.Topping", "Topping")
                        .WithMany("PresetPizzas")
                        .HasForeignKey("ToppingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BasicPizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Navigation("CrustList");

                    b.Navigation("PresetPizzas");

                    b.Navigation("SizeList");

                    b.Navigation("ToppingsList");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.Topping", b =>
                {
                    b.Navigation("PresetPizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.BasicPizza", b =>
                {
                    b.Navigation("PresetPizzas");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
