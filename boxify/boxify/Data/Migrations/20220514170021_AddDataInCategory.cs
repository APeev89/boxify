using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boxify.Data.Migrations
{
    public partial class AddDataInCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { "1", "All kinds of electronics - phones, laptops, PCs, TVs ...", "Electronics" },
                    { "2", "All types of cars", "Cars" },
                    { "3", "Аll kinds and breeds of animals", "Animals" },
                    { "4", "Clothes, shoes, accessories...", "Fashions" },
                    { "5", "Cleaning, catering, beautician...", "Services" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5");
        }
    }
}
