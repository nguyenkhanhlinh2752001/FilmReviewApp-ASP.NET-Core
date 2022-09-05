using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewApp.Database.Migrations
{
    public partial class AddRatingReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Review");
        }
    }
}
