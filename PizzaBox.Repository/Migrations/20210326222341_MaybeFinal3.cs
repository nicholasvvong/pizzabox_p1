using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class MaybeFinal3 : Migration
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
                name: "Crusts",
                columns: table => new
                {
                    CompID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    CheeseStuffed = table.Column<bool>(type: "bit", nullable: false),
                    StuffedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.CompID);
                    table.ForeignKey(
                        name: "FK_Crusts_Comps_CompID",
                        column: x => x.CompID,
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
                    CompID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.CompID);
                    table.ForeignKey(
                        name: "FK_Sizes_Comps_CompID",
                        column: x => x.CompID,
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
                        name: "FK_BasicPizza_Crusts_CrustCompID",
                        column: x => x.CrustCompID,
                        principalTable: "Crusts",
                        principalColumn: "CompID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Sizes_SizeCompID",
                        column: x => x.SizeCompID,
                        principalTable: "Sizes",
                        principalColumn: "CompID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BasicPizza_Stores_AStoreStoreID",
                        column: x => x.AStoreStoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OCJunc",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCJunc", x => new { x.OrderID, x.CustomerID });
                    table.ForeignKey(
                        name: "FK_OCJunc_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OCJunc_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrePizzas",
                columns: table => new
                {
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PresetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrePizzas", x => new { x.StoreID, x.PresetID });
                    table.ForeignKey(
                        name: "FK_PrePizzas_BasicPizza_PresetID",
                        column: x => x.PresetID,
                        principalTable: "BasicPizza",
                        principalColumn: "PresetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrePizzas_Stores_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    CompID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Inventory = table.Column<int>(type: "int", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BasicPizzaPresetID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.CompID);
                    table.ForeignKey(
                        name: "FK_Toppings_BasicPizza_BasicPizzaPresetID",
                        column: x => x.BasicPizzaPresetID,
                        principalTable: "BasicPizza",
                        principalColumn: "PresetID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Toppings_Comps_CompID",
                        column: x => x.CompID,
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
                name: "POJunc",
                columns: table => new
                {
                    PresetPizzaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PresetPizzaStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PresetPizzaPresetID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POJunc", x => new { x.PresetPizzaID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_POJunc_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POJunc_PrePizzas_PresetPizzaStoreID_PresetPizzaPresetID",
                        columns: x => new { x.PresetPizzaStoreID, x.PresetPizzaPresetID },
                        principalTable: "PrePizzas",
                        principalColumns: new[] { "StoreID", "PresetID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PTJunc",
                columns: table => new
                {
                    PresetPizzaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PresetPizzaStoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PresetPizzaPresetID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PTJunc", x => new { x.PresetPizzaID, x.ToppingID });
                    table.ForeignKey(
                        name: "FK_PTJunc_PrePizzas_PresetPizzaStoreID_PresetPizzaPresetID",
                        columns: x => new { x.PresetPizzaStoreID, x.PresetPizzaPresetID },
                        principalTable: "PrePizzas",
                        principalColumns: new[] { "StoreID", "PresetID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PTJunc_Toppings_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Toppings",
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
                name: "IX_Crusts_StoreID",
                table: "Crusts",
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
                name: "IX_ItemType_Name",
                table: "ItemType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OCJunc_CustomerID",
                table: "OCJunc",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreID",
                table: "Orders",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_POJunc_OrderID",
                table: "POJunc",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_POJunc_PresetPizzaStoreID_PresetPizzaPresetID",
                table: "POJunc",
                columns: new[] { "PresetPizzaStoreID", "PresetPizzaPresetID" });

            migrationBuilder.CreateIndex(
                name: "IX_PrePizzas_PresetID",
                table: "PrePizzas",
                column: "PresetID");

            migrationBuilder.CreateIndex(
                name: "IX_PTJunc_PresetPizzaStoreID_PresetPizzaPresetID",
                table: "PTJunc",
                columns: new[] { "PresetPizzaStoreID", "PresetPizzaPresetID" });

            migrationBuilder.CreateIndex(
                name: "IX_PTJunc_ToppingID",
                table: "PTJunc",
                column: "ToppingID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_StoreID",
                table: "Sizes",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_BasicPizzaPresetID",
                table: "Toppings",
                column: "BasicPizzaPresetID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_StoreID",
                table: "Toppings",
                column: "StoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OCJunc");

            migrationBuilder.DropTable(
                name: "POJunc");

            migrationBuilder.DropTable(
                name: "PTJunc");

            migrationBuilder.DropTable(
                name: "PrePizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "BasicPizza");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Comps");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "ItemType");
        }
    }
}
