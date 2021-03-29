using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class CustomerStoreID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Stores_StoreMangerStoreID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_StoreMangerStoreID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StoreMangerStoreID",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreManger",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreManger",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreMangerStoreID",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StoreMangerStoreID",
                table: "Customers",
                column: "StoreMangerStoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Stores_StoreMangerStoreID",
                table: "Customers",
                column: "StoreMangerStoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
