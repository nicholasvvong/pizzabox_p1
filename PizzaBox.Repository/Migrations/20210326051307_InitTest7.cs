using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class InitTest7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Stores_StoreID",
                table: "BasicPizza");

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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BasicPizza");

            migrationBuilder.RenameColumn(
                name: "StoreID",
                table: "BasicPizza",
                newName: "AStoreStoreID");

            migrationBuilder.RenameIndex(
                name: "IX_BasicPizza_StoreID",
                table: "BasicPizza",
                newName: "IX_BasicPizza_AStoreStoreID");

            migrationBuilder.InsertData(
                table: "Comps",
                columns: new[] { "CompID", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("7c3ab275-b41d-455e-ae5c-a4c746e12396"), "beef", "topping" },
                    { new Guid("0b611301-ada4-414b-bfaf-3b0f43352bef"), "regular", "crust" },
                    { new Guid("4ea9a540-a104-452f-a074-31a40f252f44"), "extra large", "size" },
                    { new Guid("50f706f5-dd78-4d75-a3dc-16df0d041238"), "large", "size" },
                    { new Guid("3e937c0b-dffd-46ed-b140-6bf5b3dbe4c7"), "medium", "size" },
                    { new Guid("fd8a1393-85fb-4022-a484-6d14118ee42e"), "small", "size" },
                    { new Guid("d07f8132-28e4-4233-a992-ad4ebb499a69"), "sausage", "topping" },
                    { new Guid("b2831169-9474-48f9-930b-99895ed6fc19"), "hand-tossed", "crust" },
                    { new Guid("fb0bf042-2ad4-4336-80c5-944a093e7e0f"), "salami", "topping" },
                    { new Guid("9cfcf550-dd9a-44f6-b40e-8cc9c46bdab6"), "pepporoni", "topping" },
                    { new Guid("14293d26-ff98-41ea-95b1-7e479dcf9c58"), "peppers", "topping" },
                    { new Guid("eabb21ca-09d4-4987-92c6-c62a545dccf8"), "olive", "topping" },
                    { new Guid("59a64af7-3d3c-490d-b6aa-cc0ab9df9105"), "mushroom", "topping" },
                    { new Guid("b14ef42c-32d2-49af-b53a-077795a3fced"), "ham", "topping" },
                    { new Guid("50134fe6-87fb-437e-b033-79cb842a4de9"), "chicken", "topping" },
                    { new Guid("2882063a-c598-41ee-be6d-753e2acf46d0"), "pineapple", "topping" },
                    { new Guid("8a887667-a3db-4408-972f-67c7eb6d7b6e"), "thin", "crust" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Stores_AStoreStoreID",
                table: "BasicPizza",
                column: "AStoreStoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Stores_AStoreStoreID",
                table: "BasicPizza");

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("0b611301-ada4-414b-bfaf-3b0f43352bef"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("14293d26-ff98-41ea-95b1-7e479dcf9c58"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("2882063a-c598-41ee-be6d-753e2acf46d0"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("3e937c0b-dffd-46ed-b140-6bf5b3dbe4c7"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("4ea9a540-a104-452f-a074-31a40f252f44"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("50134fe6-87fb-437e-b033-79cb842a4de9"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("50f706f5-dd78-4d75-a3dc-16df0d041238"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("59a64af7-3d3c-490d-b6aa-cc0ab9df9105"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("7c3ab275-b41d-455e-ae5c-a4c746e12396"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("8a887667-a3db-4408-972f-67c7eb6d7b6e"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("9cfcf550-dd9a-44f6-b40e-8cc9c46bdab6"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("b14ef42c-32d2-49af-b53a-077795a3fced"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("b2831169-9474-48f9-930b-99895ed6fc19"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("d07f8132-28e4-4233-a992-ad4ebb499a69"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("eabb21ca-09d4-4987-92c6-c62a545dccf8"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("fb0bf042-2ad4-4336-80c5-944a093e7e0f"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("fd8a1393-85fb-4022-a484-6d14118ee42e"));

            migrationBuilder.RenameColumn(
                name: "AStoreStoreID",
                table: "BasicPizza",
                newName: "StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_BasicPizza_AStoreStoreID",
                table: "BasicPizza",
                newName: "IX_BasicPizza_StoreID");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BasicPizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Stores_StoreID",
                table: "BasicPizza",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
