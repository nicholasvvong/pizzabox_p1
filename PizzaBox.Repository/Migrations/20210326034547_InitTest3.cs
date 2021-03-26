using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class InitTest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Crust_CrustID_CrustStoreID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Size_SizeID_SizeStoreID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Crust_Stores_StoreID",
                table: "Crust");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_Stores_StoreID",
                table: "Size");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_BasicPizza_BasicPizzaPresetID",
                table: "Topping");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Stores_StoreID",
                table: "Topping");

            migrationBuilder.DropIndex(
                name: "IX_BasicPizza_CrustID_CrustStoreID",
                table: "BasicPizza");

            migrationBuilder.DropIndex(
                name: "IX_BasicPizza_SizeID_SizeStoreID",
                table: "BasicPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.DropIndex(
                name: "IX_Topping_StoreID",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Size_StoreID",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crust",
                table: "Crust");

            migrationBuilder.DropIndex(
                name: "IX_Crust_StoreID",
                table: "Crust");

            migrationBuilder.DropColumn(
                name: "CrustID",
                table: "BasicPizza");

            migrationBuilder.DropColumn(
                name: "CrustStoreID",
                table: "BasicPizza");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Topping");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Topping");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Size");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Crust");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Crust");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "Crust",
                newName: "Crusts");

            migrationBuilder.RenameColumn(
                name: "SizeStoreID",
                table: "BasicPizza",
                newName: "SizeCompID");

            migrationBuilder.RenameColumn(
                name: "SizeID",
                table: "BasicPizza",
                newName: "CrustCompID");

            migrationBuilder.RenameIndex(
                name: "IX_Topping_BasicPizzaPresetID",
                table: "Toppings",
                newName: "IX_Toppings_BasicPizzaPresetID");

            migrationBuilder.AddColumn<Guid>(
                name: "AStoreStoreID",
                table: "Toppings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AStoreStoreID",
                table: "Sizes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AStoreStoreID",
                table: "Crusts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "CompID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "CompID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts",
                column: "CompID");

            migrationBuilder.CreateTable(
                name: "Comps",
                columns: table => new
                {
                    CompID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comps", x => x.CompID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_CrustCompID",
                table: "BasicPizza",
                column: "CrustCompID");

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_SizeCompID",
                table: "BasicPizza",
                column: "SizeCompID");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_AStoreStoreID",
                table: "Toppings",
                column: "AStoreStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_AStoreStoreID",
                table: "Sizes",
                column: "AStoreStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Crusts_AStoreStoreID",
                table: "Crusts",
                column: "AStoreStoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Crusts_CrustCompID",
                table: "BasicPizza",
                column: "CrustCompID",
                principalTable: "Crusts",
                principalColumn: "CompID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Sizes_SizeCompID",
                table: "BasicPizza",
                column: "SizeCompID",
                principalTable: "Sizes",
                principalColumn: "CompID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crusts_Comps_CompID",
                table: "Crusts",
                column: "CompID",
                principalTable: "Comps",
                principalColumn: "CompID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crusts_Stores_AStoreStoreID",
                table: "Crusts",
                column: "AStoreStoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Comps_CompID",
                table: "Sizes",
                column: "CompID",
                principalTable: "Comps",
                principalColumn: "CompID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Stores_AStoreStoreID",
                table: "Sizes",
                column: "AStoreStoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_BasicPizza_BasicPizzaPresetID",
                table: "Toppings",
                column: "BasicPizzaPresetID",
                principalTable: "BasicPizza",
                principalColumn: "PresetID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Comps_CompID",
                table: "Toppings",
                column: "CompID",
                principalTable: "Comps",
                principalColumn: "CompID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Stores_AStoreStoreID",
                table: "Toppings",
                column: "AStoreStoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Crusts_CrustCompID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Sizes_SizeCompID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Crusts_Comps_CompID",
                table: "Crusts");

            migrationBuilder.DropForeignKey(
                name: "FK_Crusts_Stores_AStoreStoreID",
                table: "Crusts");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Comps_CompID",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Stores_AStoreStoreID",
                table: "Sizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_BasicPizza_BasicPizzaPresetID",
                table: "Toppings");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Comps_CompID",
                table: "Toppings");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Stores_AStoreStoreID",
                table: "Toppings");

            migrationBuilder.DropTable(
                name: "Comps");

            migrationBuilder.DropIndex(
                name: "IX_BasicPizza_CrustCompID",
                table: "BasicPizza");

            migrationBuilder.DropIndex(
                name: "IX_BasicPizza_SizeCompID",
                table: "BasicPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_AStoreStoreID",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_AStoreStoreID",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts");

            migrationBuilder.DropIndex(
                name: "IX_Crusts_AStoreStoreID",
                table: "Crusts");

            migrationBuilder.DropColumn(
                name: "AStoreStoreID",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "AStoreStoreID",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "AStoreStoreID",
                table: "Crusts");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "Crusts",
                newName: "Crust");

            migrationBuilder.RenameColumn(
                name: "SizeCompID",
                table: "BasicPizza",
                newName: "SizeStoreID");

            migrationBuilder.RenameColumn(
                name: "CrustCompID",
                table: "BasicPizza",
                newName: "SizeID");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_BasicPizzaPresetID",
                table: "Topping",
                newName: "IX_Topping_BasicPizzaPresetID");

            migrationBuilder.AddColumn<Guid>(
                name: "CrustID",
                table: "BasicPizza",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CrustStoreID",
                table: "BasicPizza",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Topping",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Topping",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Size",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Size",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Crust",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Crust",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                columns: new[] { "ToppingID", "StoreID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                columns: new[] { "SizeID", "StoreID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crust",
                table: "Crust",
                columns: new[] { "CrustID", "StoreID" });

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_CrustID_CrustStoreID",
                table: "BasicPizza",
                columns: new[] { "CrustID", "CrustStoreID" });

            migrationBuilder.CreateIndex(
                name: "IX_BasicPizza_SizeID_SizeStoreID",
                table: "BasicPizza",
                columns: new[] { "SizeID", "SizeStoreID" });

            migrationBuilder.CreateIndex(
                name: "IX_Topping_StoreID",
                table: "Topping",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Size_StoreID",
                table: "Size",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Crust_StoreID",
                table: "Crust",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Crust_CrustID_CrustStoreID",
                table: "BasicPizza",
                columns: new[] { "CrustID", "CrustStoreID" },
                principalTable: "Crust",
                principalColumns: new[] { "CrustID", "StoreID" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Size_SizeID_SizeStoreID",
                table: "BasicPizza",
                columns: new[] { "SizeID", "SizeStoreID" },
                principalTable: "Size",
                principalColumns: new[] { "SizeID", "StoreID" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crust_Stores_StoreID",
                table: "Crust",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Size_Stores_StoreID",
                table: "Size",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_BasicPizza_BasicPizzaPresetID",
                table: "Topping",
                column: "BasicPizzaPresetID",
                principalTable: "BasicPizza",
                principalColumn: "PresetID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Stores_StoreID",
                table: "Topping",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
