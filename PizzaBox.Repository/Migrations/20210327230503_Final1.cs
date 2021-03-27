using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class Final1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Comps_CrustCompID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Comps_SizeCompID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Comps_Stores_Size_StoreID",
                table: "Comps");

            migrationBuilder.DropForeignKey(
                name: "FK_Comps_Stores_StoreID",
                table: "Comps");

            migrationBuilder.DropForeignKey(
                name: "FK_Comps_Stores_Topping_StoreID",
                table: "Comps");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetPizza_Comps_ToppingID",
                table: "PresetPizza");

            migrationBuilder.DropIndex(
                name: "IX_Comps_Size_StoreID",
                table: "Comps");

            migrationBuilder.DropIndex(
                name: "IX_Comps_StoreID",
                table: "Comps");

            migrationBuilder.DropIndex(
                name: "IX_Comps_Topping_StoreID",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "CheeseStuffed",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Size_Inventory",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Size_Price",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Size_StoreID",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "StuffedPrice",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Topping_Inventory",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Topping_Price",
                table: "Comps");

            migrationBuilder.DropColumn(
                name: "Topping_StoreID",
                table: "Comps");

            migrationBuilder.RenameColumn(
                name: "SizeCompID",
                table: "BasicPizza",
                newName: "SizeID");

            migrationBuilder.RenameColumn(
                name: "CrustCompID",
                table: "BasicPizza",
                newName: "CrustID");

            migrationBuilder.RenameIndex(
                name: "IX_BasicPizza_SizeCompID",
                table: "BasicPizza",
                newName: "IX_BasicPizza_SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_BasicPizza_CrustCompID",
                table: "BasicPizza",
                newName: "IX_BasicPizza_CrustID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_PizzaTypeCompID",
                table: "Crusts",
                column: "PizzaTypeCompID");

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_StoreID",
                table: "Crusts",
                column: "StoreID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Crusts_CrustID",
                table: "BasicPizza",
                column: "CrustID",
                principalTable: "Crusts",
                principalColumn: "CrustID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Sizes_SizeID",
                table: "BasicPizza",
                column: "SizeID",
                principalTable: "Sizes",
                principalColumn: "SizeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetPizza_Toppings_ToppingID",
                table: "PresetPizza",
                column: "ToppingID",
                principalTable: "Toppings",
                principalColumn: "ToppingID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Crusts_CrustID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Sizes_SizeID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetPizza_Toppings_ToppingID",
                table: "PresetPizza");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.RenameColumn(
                name: "SizeID",
                table: "BasicPizza",
                newName: "SizeCompID");

            migrationBuilder.RenameColumn(
                name: "CrustID",
                table: "BasicPizza",
                newName: "CrustCompID");

            migrationBuilder.RenameIndex(
                name: "IX_BasicPizza_SizeID",
                table: "BasicPizza",
                newName: "IX_BasicPizza_SizeCompID");

            migrationBuilder.RenameIndex(
                name: "IX_BasicPizza_CrustID",
                table: "BasicPizza",
                newName: "IX_BasicPizza_CrustCompID");

            migrationBuilder.AddColumn<bool>(
                name: "CheeseStuffed",
                table: "Comps",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Comps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Inventory",
                table: "Comps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Comps",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size_Inventory",
                table: "Comps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Size_Price",
                table: "Comps",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Size_StoreID",
                table: "Comps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreID",
                table: "Comps",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StuffedPrice",
                table: "Comps",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Topping_Inventory",
                table: "Comps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Topping_Price",
                table: "Comps",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Topping_StoreID",
                table: "Comps",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Comps_CrustCompID",
                table: "BasicPizza",
                column: "CrustCompID",
                principalTable: "Comps",
                principalColumn: "CompID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Comps_SizeCompID",
                table: "BasicPizza",
                column: "SizeCompID",
                principalTable: "Comps",
                principalColumn: "CompID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comps_Stores_Size_StoreID",
                table: "Comps",
                column: "Size_StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comps_Stores_StoreID",
                table: "Comps",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comps_Stores_Topping_StoreID",
                table: "Comps",
                column: "Topping_StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetPizza_Comps_ToppingID",
                table: "PresetPizza",
                column: "ToppingID",
                principalTable: "Comps",
                principalColumn: "CompID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
