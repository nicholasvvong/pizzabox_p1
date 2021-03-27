using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class Final0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    TypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxToppings = table.Column<int>(type: "int", nullable: false),
                    MaxPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxPizzas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "Comps",
                columns: table => new
                {
                    CompID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ITypeTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Inventory = table.Column<int>(type: "int", nullable: true),
                    CheeseStuffed = table.Column<bool>(type: "bit", nullable: true),
                    StuffedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Size_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Size_Inventory = table.Column<int>(type: "int", nullable: true),
                    Size_StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Topping_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Topping_Inventory = table.Column<int>(type: "int", nullable: true),
                    Topping_StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comps", x => x.CompID);
                    table.ForeignKey(
                        name: "FK_Comps_ItemType_ITypeTypeID",
                        column: x => x.ITypeTypeID,
                        principalTable: "ItemType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comps_Stores_Size_StoreID",
                        column: x => x.Size_StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comps_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comps_Stores_Topping_StoreID",
                        column: x => x.Topping_StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastTimeOrdered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastStoreStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreMangerStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Stores_LastStoreStoreID",
                        column: x => x.LastStoreStoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Stores_StoreMangerStoreID",
                        column: x => x.StoreMangerStoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasicPizza",
                columns: table => new
                {
                    PresetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CrustCompID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SizeCompID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AStoreStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicPizza", x => x.PresetID);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Comps_CrustCompID",
                        column: x => x.CrustCompID,
                        principalTable: "Comps",
                        principalColumn: "CompID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Comps_SizeCompID",
                        column: x => x.SizeCompID,
                        principalTable: "Comps",
                        principalColumn: "CompID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Stores_AStoreStoreID",
                        column: x => x.AStoreStoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresetPizza",
                columns: table => new
                {
                    BasicPizzaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresetPizza", x => new { x.BasicPizzaID, x.ToppingID });
                    table.ForeignKey(
                        name: "FK_PresetPizza_BasicPizza_BasicPizzaID",
                        column: x => x.BasicPizzaID,
                        principalTable: "BasicPizza",
                        principalColumn: "PresetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresetPizza_Comps_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Comps",
                        principalColumn: "CompID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_AStoreStoreID",
                table: "BasicPizza",
                column: "AStoreStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_CrustCompID",
                table: "BasicPizza",
                column: "CrustCompID");

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_OrderID",
                table: "BasicPizza",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_SizeCompID",
                table: "BasicPizza",
                column: "SizeCompID");

            migrationBuilder.CreateIndex(
                name: "IX_Comps_ITypeTypeID",
                table: "Comps",
                column: "ITypeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Comps_Name",
                table: "Comps",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comps_Size_StoreID",
                table: "Comps",
                column: "Size_StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Comps_StoreID",
                table: "Comps",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Comps_Topping_StoreID",
                table: "Comps",
                column: "Topping_StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LastStoreStoreID",
                table: "Customers",
                column: "LastStoreStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StoreMangerStoreID",
                table: "Customers",
                column: "StoreMangerStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemType_Name",
                table: "ItemType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreID",
                table: "Orders",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_PresetPizza_ToppingID",
                table: "PresetPizza",
                column: "ToppingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresetPizza");

            migrationBuilder.DropTable(
                name: "BasicPizza");

            migrationBuilder.DropTable(
                name: "Comps");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
