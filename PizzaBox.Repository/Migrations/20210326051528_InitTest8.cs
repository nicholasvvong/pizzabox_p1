using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Repository.Migrations
{
    public partial class InitTest8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
