using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class InitTest6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MaxPrice",
                table: "Stores",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Comps",
                columns: new[] { "CompID", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("5e094c48-0c46-46cc-b5c9-08742915fb58"), "beef", "topping" },
                    { new Guid("bf364549-f6c3-4882-94a1-f1e1a3560cb1"), "regular", "crust" },
                    { new Guid("5562ac82-fd81-4b5b-8005-f4f95cc12530"), "extra large", "size" },
                    { new Guid("45e88df6-a7fc-4610-beb6-3ef78c028d46"), "large", "size" },
                    { new Guid("a30f130c-624a-4591-8669-e1286b73a6d8"), "medium", "size" },
                    { new Guid("a2a22d04-e339-46f8-940b-0fc528e0c0aa"), "small", "size" },
                    { new Guid("fab3b314-9b66-4c79-8e0b-e9629173f109"), "sausage", "topping" },
                    { new Guid("ee348a74-55ea-4639-85b7-271b32b252a9"), "hand-tossed", "crust" },
                    { new Guid("e17608bb-e944-4f15-a70a-9e6199848233"), "salami", "topping" },
                    { new Guid("f3abe031-d34f-4344-b984-d06eb6f0b6fd"), "pepporoni", "topping" },
                    { new Guid("51a7cff2-9d2c-4790-982b-3996bf721286"), "peppers", "topping" },
                    { new Guid("8bdfc454-61fd-4bd9-a766-7a4ef88574d7"), "olive", "topping" },
                    { new Guid("2f3c3a36-ec6f-4da4-9e77-12f1aeee5764"), "mushroom", "topping" },
                    { new Guid("0092752d-79f1-40ab-a5b9-c2b28cd1b59a"), "ham", "topping" },
                    { new Guid("21f81832-3d00-45ef-8886-dc52d371cfbf"), "chicken", "topping" },
                    { new Guid("36e2b574-e845-45de-bd9d-8207951bccd8"), "pineapple", "topping" },
                    { new Guid("274966f0-6536-4467-8580-fe52307eccaf"), "thin", "crust" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("0092752d-79f1-40ab-a5b9-c2b28cd1b59a"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("21f81832-3d00-45ef-8886-dc52d371cfbf"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("274966f0-6536-4467-8580-fe52307eccaf"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("2f3c3a36-ec6f-4da4-9e77-12f1aeee5764"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("36e2b574-e845-45de-bd9d-8207951bccd8"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("45e88df6-a7fc-4610-beb6-3ef78c028d46"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("51a7cff2-9d2c-4790-982b-3996bf721286"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("5562ac82-fd81-4b5b-8005-f4f95cc12530"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("5e094c48-0c46-46cc-b5c9-08742915fb58"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("8bdfc454-61fd-4bd9-a766-7a4ef88574d7"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("a2a22d04-e339-46f8-940b-0fc528e0c0aa"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("a30f130c-624a-4591-8669-e1286b73a6d8"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("bf364549-f6c3-4882-94a1-f1e1a3560cb1"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("e17608bb-e944-4f15-a70a-9e6199848233"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("ee348a74-55ea-4639-85b7-271b32b252a9"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("f3abe031-d34f-4344-b984-d06eb6f0b6fd"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("fab3b314-9b66-4c79-8e0b-e9629173f109"));

            migrationBuilder.AlterColumn<int>(
                name: "MaxPrice",
                table: "Stores",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
