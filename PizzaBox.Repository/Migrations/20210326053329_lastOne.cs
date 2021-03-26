using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class lastOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Stores_AStoreStoreID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_BasicPizza_BasicPizzaPresetID",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_BasicPizzaPresetID",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasicPizza",
                table: "BasicPizza");

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("13b21b42-484e-4409-9686-18c61ddf517d"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("2916da14-44aa-479b-91b7-a70621209e72"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("305f30ee-abac-4713-8170-7b96b3f96113"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("442138dc-4cf1-40fa-93d5-8769e58a85ad"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("44fca71d-de55-4f63-8f03-1769b9940cb0"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("46612f32-7608-4491-b24a-cd8b33452b8a"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("4d6e00cb-b1ce-4e84-9022-bfd75477ecb7"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("53d91efa-8222-4873-b119-96b547ff67ef"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("825975d9-9890-41e2-9b73-c6b7e890a7fd"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("8af74dd7-3f5d-4c60-9b3b-a55463735b55"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("a1e96236-67d4-4cc2-9d15-a9c5de523062"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("a41882f1-f83e-4480-a439-aee7fdeef264"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("b2b3bc21-3287-4716-88b2-d2685d338b3f"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("c6ceb6b5-782b-4f6c-8cda-c2fb09352e83"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("d6adf42e-fb03-4ea2-84c0-cfa4ecfc6420"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("f7e58f1d-f758-4564-82ff-90e47ad749cf"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("ff2d88de-fb67-4e6b-b3af-421a3d9d5838"));

            migrationBuilder.RenameColumn(
                name: "AStoreStoreID",
                table: "BasicPizza",
                newName: "StoreID");

            migrationBuilder.RenameIndex(
                name: "IX_BasicPizza_AStoreStoreID",
                table: "BasicPizza",
                newName: "IX_BasicPizza_StoreID");

            migrationBuilder.AddColumn<string>(
                name: "BasicPizzaType",
                table: "Toppings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "BasicPizza",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BasicPizzaID",
                table: "BasicPizza",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BasicPizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasicPizza",
                table: "BasicPizza",
                columns: new[] { "PresetID", "Type" });

            migrationBuilder.InsertData(
                table: "Comps",
                columns: new[] { "CompID", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("4de79d51-f00f-4dbf-a253-4dedb6626aca"), "beef", "topping" },
                    { new Guid("007c8bf4-3ab5-468a-b2f1-35bdd626bc19"), "regular", "crust" },
                    { new Guid("64f9f15b-897d-4ecf-bcd4-964a61fb2600"), "extra large", "size" },
                    { new Guid("79f3ac47-b1f9-4d37-a60b-5beeeea6a6b3"), "large", "size" },
                    { new Guid("7fdd66bc-dd4e-45f2-8594-f5fbefb57ed0"), "medium", "size" },
                    { new Guid("45d19695-0adb-4f4a-bd24-f1e35be32a50"), "small", "size" },
                    { new Guid("eda1cc4d-3811-4395-b1b8-d351f284dc19"), "sausage", "topping" },
                    { new Guid("13915804-2597-47ce-a580-279c5a77064a"), "hand-tossed", "crust" },
                    { new Guid("60153447-305c-4134-8fc3-e721c4ccda12"), "salami", "topping" },
                    { new Guid("427c6fdc-eae9-4fb5-ab8f-50c512ccc241"), "pepporoni", "topping" },
                    { new Guid("2923722e-50dd-4e8f-a87e-b13f6fdc4dfa"), "peppers", "topping" },
                    { new Guid("c34134ae-f26b-4778-a187-ee053a59ad05"), "olive", "topping" },
                    { new Guid("3f12fff3-db59-4456-9458-d945a2575f78"), "mushroom", "topping" },
                    { new Guid("afe5ed04-1a71-4842-ac4c-cdf49342d50d"), "ham", "topping" },
                    { new Guid("f22ea6c9-ed90-44a4-892d-17d5729eb936"), "chicken", "topping" },
                    { new Guid("0d099659-f98c-412a-a658-da0834783bf4"), "pineapple", "topping" },
                    { new Guid("c0a06482-b60f-4b1c-87f8-1cd99caf6c20"), "thin", "crust" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_BasicPizzaPresetID_BasicPizzaType",
                table: "Toppings",
                columns: new[] { "BasicPizzaPresetID", "BasicPizzaType" });

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Stores_StoreID",
                table: "BasicPizza",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "StoreID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_BasicPizza_BasicPizzaPresetID_BasicPizzaType",
                table: "Toppings",
                columns: new[] { "BasicPizzaPresetID", "BasicPizzaType" },
                principalTable: "BasicPizza",
                principalColumns: new[] { "PresetID", "Type" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicPizza_Stores_StoreID",
                table: "BasicPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_BasicPizza_BasicPizzaPresetID_BasicPizzaType",
                table: "Toppings");

            migrationBuilder.DropIndex(
                name: "IX_Toppings_BasicPizzaPresetID_BasicPizzaType",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasicPizza",
                table: "BasicPizza");

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("007c8bf4-3ab5-468a-b2f1-35bdd626bc19"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("0d099659-f98c-412a-a658-da0834783bf4"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("13915804-2597-47ce-a580-279c5a77064a"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("2923722e-50dd-4e8f-a87e-b13f6fdc4dfa"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("3f12fff3-db59-4456-9458-d945a2575f78"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("427c6fdc-eae9-4fb5-ab8f-50c512ccc241"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("45d19695-0adb-4f4a-bd24-f1e35be32a50"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("4de79d51-f00f-4dbf-a253-4dedb6626aca"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("60153447-305c-4134-8fc3-e721c4ccda12"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("64f9f15b-897d-4ecf-bcd4-964a61fb2600"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("79f3ac47-b1f9-4d37-a60b-5beeeea6a6b3"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("7fdd66bc-dd4e-45f2-8594-f5fbefb57ed0"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("afe5ed04-1a71-4842-ac4c-cdf49342d50d"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("c0a06482-b60f-4b1c-87f8-1cd99caf6c20"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("c34134ae-f26b-4778-a187-ee053a59ad05"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("eda1cc4d-3811-4395-b1b8-d351f284dc19"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("f22ea6c9-ed90-44a4-892d-17d5729eb936"));

            migrationBuilder.DropColumn(
                name: "BasicPizzaType",
                table: "Toppings");

            migrationBuilder.DropColumn(
                name: "BasicPizzaID",
                table: "BasicPizza");

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

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "BasicPizza",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasicPizza",
                table: "BasicPizza",
                column: "PresetID");

            migrationBuilder.InsertData(
                table: "Comps",
                columns: new[] { "CompID", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("442138dc-4cf1-40fa-93d5-8769e58a85ad"), "beef", "topping" },
                    { new Guid("f7e58f1d-f758-4564-82ff-90e47ad749cf"), "regular", "crust" },
                    { new Guid("2916da14-44aa-479b-91b7-a70621209e72"), "extra large", "size" },
                    { new Guid("c6ceb6b5-782b-4f6c-8cda-c2fb09352e83"), "large", "size" },
                    { new Guid("b2b3bc21-3287-4716-88b2-d2685d338b3f"), "medium", "size" },
                    { new Guid("ff2d88de-fb67-4e6b-b3af-421a3d9d5838"), "small", "size" },
                    { new Guid("4d6e00cb-b1ce-4e84-9022-bfd75477ecb7"), "sausage", "topping" },
                    { new Guid("8af74dd7-3f5d-4c60-9b3b-a55463735b55"), "hand-tossed", "crust" },
                    { new Guid("a1e96236-67d4-4cc2-9d15-a9c5de523062"), "salami", "topping" },
                    { new Guid("46612f32-7608-4491-b24a-cd8b33452b8a"), "pepporoni", "topping" },
                    { new Guid("d6adf42e-fb03-4ea2-84c0-cfa4ecfc6420"), "peppers", "topping" },
                    { new Guid("305f30ee-abac-4713-8170-7b96b3f96113"), "olive", "topping" },
                    { new Guid("13b21b42-484e-4409-9686-18c61ddf517d"), "mushroom", "topping" },
                    { new Guid("a41882f1-f83e-4480-a439-aee7fdeef264"), "ham", "topping" },
                    { new Guid("44fca71d-de55-4f63-8f03-1769b9940cb0"), "chicken", "topping" },
                    { new Guid("53d91efa-8222-4873-b119-96b547ff67ef"), "pineapple", "topping" },
                    { new Guid("825975d9-9890-41e2-9b73-c6b7e890a7fd"), "thin", "crust" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_BasicPizzaPresetID",
                table: "Toppings",
                column: "BasicPizzaPresetID");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicPizza_Stores_AStoreStoreID",
                table: "BasicPizza",
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
        }
    }
}
