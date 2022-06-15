using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace boxify.Data.Migrations
{
    public partial class AddedColumnFavoriteInAdTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFavorite",
                table: "Ads",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFavorite",
                table: "Ads");
        }
    }
}
