using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class InitTest10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("1f037e56-349f-43c5-a6a6-5ee604d8bcd3"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("1f8b34f3-a769-4fe8-a82e-21aaa6663408"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("2cf8e1d5-9cbf-4783-9590-b13c3c312480"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("3126db57-50a8-4fc7-a2af-e009fdc57681"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("44c03a60-9e68-43d0-884f-4bdfcdf3d92e"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("5ecbe7cd-4b35-41da-b349-91e0eb8933d1"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("6c2d1309-7abb-428f-8efa-7868cefe8d7d"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("925f3169-e8bb-47d1-bc6d-f088e6768eb0"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("9bd9c616-3f95-4535-8da6-4901ac8f3174"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("a0b1d6b2-6cd6-4b66-8d5f-4d0449fc6914"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("a249b8b2-9aca-4101-b303-63e9ad9ad8b8"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("a86023e3-feb8-446f-815b-ea026ae062ae"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("cbfcf83c-99e4-4ce1-95e6-9b1357973c97"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("cd0ee1e4-cf0a-48f6-8e77-0f3daa9678f2"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("dee4b8ac-fba9-4761-a5a9-1005a3106434"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("e689d6bd-c2b8-4c5d-8415-6b50322aea12"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("f23c8e16-d937-45c7-95cf-323e5662b05b"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Comps",
                columns: new[] { "CompID", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("6c2d1309-7abb-428f-8efa-7868cefe8d7d"), "beef", "topping" },
                    { new Guid("2cf8e1d5-9cbf-4783-9590-b13c3c312480"), "regular", "crust" },
                    { new Guid("5ecbe7cd-4b35-41da-b349-91e0eb8933d1"), "extra large", "size" },
                    { new Guid("cbfcf83c-99e4-4ce1-95e6-9b1357973c97"), "large", "size" },
                    { new Guid("1f8b34f3-a769-4fe8-a82e-21aaa6663408"), "medium", "size" },
                    { new Guid("f23c8e16-d937-45c7-95cf-323e5662b05b"), "small", "size" },
                    { new Guid("cd0ee1e4-cf0a-48f6-8e77-0f3daa9678f2"), "sausage", "topping" },
                    { new Guid("a249b8b2-9aca-4101-b303-63e9ad9ad8b8"), "hand-tossed", "crust" },
                    { new Guid("a86023e3-feb8-446f-815b-ea026ae062ae"), "salami", "topping" },
                    { new Guid("9bd9c616-3f95-4535-8da6-4901ac8f3174"), "pepporoni", "topping" },
                    { new Guid("925f3169-e8bb-47d1-bc6d-f088e6768eb0"), "peppers", "topping" },
                    { new Guid("1f037e56-349f-43c5-a6a6-5ee604d8bcd3"), "olive", "topping" },
                    { new Guid("3126db57-50a8-4fc7-a2af-e009fdc57681"), "mushroom", "topping" },
                    { new Guid("dee4b8ac-fba9-4761-a5a9-1005a3106434"), "ham", "topping" },
                    { new Guid("44c03a60-9e68-43d0-884f-4bdfcdf3d92e"), "chicken", "topping" },
                    { new Guid("e689d6bd-c2b8-4c5d-8415-6b50322aea12"), "pineapple", "topping" },
                    { new Guid("a0b1d6b2-6cd6-4b66-8d5f-4d0449fc6914"), "thin", "crust" }
                });
        }
    }
}
