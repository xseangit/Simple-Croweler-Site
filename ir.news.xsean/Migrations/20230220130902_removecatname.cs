using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ir.news.xsean.Migrations
{
    public partial class removecatname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatgoryName",
                table: "newss");

            migrationBuilder.DropColumn(
                name: "CatgoryName",
                table: "newsfi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CatgoryName",
                table: "newss",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatgoryName",
                table: "newsfi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
