using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class FinalCustomerOrders1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastTimeOrdered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastStore = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreManger = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

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
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cust = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Store = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JSONPizzaOrder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
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
                    ITypeTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    CrustID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    CheeseStuffed = table.Column<bool>(type: "bit", nullable: false),
                    StuffedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PizzaTypeCompID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.CrustID);
                    table.ForeignKey(
                        name: "FK_Crusts_Comps_PizzaTypeCompID",
                        column: x => x.PizzaTypeCompID,
                        principalTable: "Comps",
                        principalColumn: "CompID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crusts_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PizzaTypeCompID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                    table.ForeignKey(
                        name: "FK_Sizes_Comps_PizzaTypeCompID",
                        column: x => x.PizzaTypeCompID,
                        principalTable: "Comps",
                        principalColumn: "CompID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sizes_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PizzaTypeCompID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingID);
                    table.ForeignKey(
                        name: "FK_Toppings_Comps_PizzaTypeCompID",
                        column: x => x.PizzaTypeCompID,
                        principalTable: "Comps",
                        principalColumn: "CompID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Toppings_Stores_StoreID",
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
                    SizeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AStoreStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicPizza", x => x.PresetID);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Crusts_CrustID",
                        column: x => x.CrustID,
                        principalTable: "Crusts",
                        principalColumn: "CrustID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
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
                        name: "FK_PresetPizza_Toppings_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Toppings",
                        principalColumn: "ToppingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_AStoreStoreID",
                table: "BasicPizza",
                column: "AStoreStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_CrustID",
                table: "BasicPizza",
                column: "CrustID");

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_OrderID",
                table: "BasicPizza",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_SizeID",
                table: "BasicPizza",
                column: "SizeID");

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
                name: "IX_Crusts_PizzaTypeCompID",
                table: "Crusts",
                column: "PizzaTypeCompID");

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_StoreID",
                table: "Crusts",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemType_Name",
                table: "ItemType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PresetPizza_ToppingID",
                table: "PresetPizza",
                column: "ToppingID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_PizzaTypeCompID",
                table: "Sizes",
                column: "PizzaTypeCompID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_StoreID",
                table: "Sizes",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaTypeCompID",
                table: "Toppings",
                column: "PizzaTypeCompID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_StoreID",
                table: "Toppings",
                column: "StoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PresetPizza");

            migrationBuilder.DropTable(
                name: "BasicPizza");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Comps");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "ItemType");
        }
    }
}
