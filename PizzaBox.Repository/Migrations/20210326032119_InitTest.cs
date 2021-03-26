using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class InitTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxToppings = table.Column<int>(type: "int", nullable: false),
                    MaxPrice = table.Column<int>(type: "int", nullable: false),
                    MaxPizzas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    CrustID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    CheeseStuffed = table.Column<bool>(type: "bit", nullable: false),
                    StuffedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => new { x.CrustID, x.StoreID });
                    table.ForeignKey(
                        name: "FK_Crust_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Size",
                columns: table => new
                {
                    SizeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    CompID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => new { x.SizeID, x.StoreID });
                    table.ForeignKey(
                        name: "FK_Size_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
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
                    CrustID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CrustStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SizeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SizeStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicPizza", x => x.PresetID);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Crust_CrustID_CrustStoreID",
                        columns: x => new { x.CrustID, x.CrustStoreID },
                        principalTable: "Crust",
                        principalColumns: new[] { "CrustID", "StoreID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Size_SizeID_SizeStoreID",
                        columns: x => new { x.SizeID, x.SizeStoreID },
                        principalTable: "Size",
                        principalColumns: new[] { "SizeID", "StoreID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ToppingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    BasicPizzaPresetID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => new { x.ToppingID, x.StoreID });
                    table.ForeignKey(
                        name: "FK_Topping_BasicPizza_BasicPizzaPresetID",
                        column: x => x.BasicPizzaPresetID,
                        principalTable: "BasicPizza",
                        principalColumn: "PresetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topping_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_CrustID_CrustStoreID",
                table: "BasicPizza",
                columns: new[] { "CrustID", "CrustStoreID" });

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_OrderID",
                table: "BasicPizza",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_SizeID_SizeStoreID",
                table: "BasicPizza",
                columns: new[] { "SizeID", "SizeStoreID" });

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_StoreID",
                table: "BasicPizza",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Crust_StoreID",
                table: "Crust",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LastStoreStoreID",
                table: "Customers",
                column: "LastStoreStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StoreMangerStoreID",
                table: "Customers",
                column: "StoreMangerStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreID",
                table: "Orders",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Size_StoreID",
                table: "Size",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_BasicPizzaPresetID",
                table: "Topping",
                column: "BasicPizzaPresetID");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_StoreID",
                table: "Topping",
                column: "StoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "BasicPizza");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
