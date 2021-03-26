using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class InitTest9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("00f6ad87-790f-4c73-a72a-c41c2b3193a8"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("0735291d-0c85-43e3-b80f-6f943af6b10d"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("114c6890-38a8-4b3d-866c-ab892832a9be"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("1f11fce1-e013-4b3e-b216-66037310ac10"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("25d69bf8-8b64-4311-b742-af694849c2f3"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("3860bac9-6f55-4f74-a289-006aaa5e0431"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("66f30ba9-1854-44c6-8650-1284095a5a69"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("6a35cbe2-e9d3-430f-898e-2d6af98750be"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("a24759cc-1a6d-43b9-bf13-85a12ef8c992"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("acc9474a-365a-49c3-be42-d894cce4ec7e"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("c415de06-c7d3-4f3b-a6e9-c834bc7b3fc8"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("c53fab5d-18d9-4f87-b965-e588015a5771"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("c678c0d6-74b0-4a53-90b8-9b31b36daa72"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("c8fde2cf-15a9-4273-b4cb-41fcfc8bfa9e"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("de3b91a3-6849-40b7-ad30-7b325525f447"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("e2829ef5-3afe-4da5-8ec4-ce67379d8c36"));

            migrationBuilder.DeleteData(
                table: "Comps",
                keyColumn: "CompID",
                keyValue: new Guid("ea37cfa6-e8c6-4b8c-8adc-2a95646fd887"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("114c6890-38a8-4b3d-866c-ab892832a9be"), "beef", "topping" },
                    { new Guid("c8fde2cf-15a9-4273-b4cb-41fcfc8bfa9e"), "regular", "crust" },
                    { new Guid("c53fab5d-18d9-4f87-b965-e588015a5771"), "extra large", "size" },
                    { new Guid("de3b91a3-6849-40b7-ad30-7b325525f447"), "large", "size" },
                    { new Guid("66f30ba9-1854-44c6-8650-1284095a5a69"), "medium", "size" },
                    { new Guid("c415de06-c7d3-4f3b-a6e9-c834bc7b3fc8"), "small", "size" },
                    { new Guid("e2829ef5-3afe-4da5-8ec4-ce67379d8c36"), "sausage", "topping" },
                    { new Guid("0735291d-0c85-43e3-b80f-6f943af6b10d"), "hand-tossed", "crust" },
                    { new Guid("c678c0d6-74b0-4a53-90b8-9b31b36daa72"), "salami", "topping" },
                    { new Guid("25d69bf8-8b64-4311-b742-af694849c2f3"), "pepporoni", "topping" },
                    { new Guid("acc9474a-365a-49c3-be42-d894cce4ec7e"), "peppers", "topping" },
                    { new Guid("6a35cbe2-e9d3-430f-898e-2d6af98750be"), "olive", "topping" },
                    { new Guid("00f6ad87-790f-4c73-a72a-c41c2b3193a8"), "mushroom", "topping" },
                    { new Guid("ea37cfa6-e8c6-4b8c-8adc-2a95646fd887"), "ham", "topping" },
                    { new Guid("a24759cc-1a6d-43b9-bf13-85a12ef8c992"), "chicken", "topping" },
                    { new Guid("1f11fce1-e013-4b3e-b216-66037310ac10"), "pineapple", "topping" },
                    { new Guid("3860bac9-6f55-4f74-a289-006aaa5e0431"), "thin", "crust" }
                });
        }
    }
}
