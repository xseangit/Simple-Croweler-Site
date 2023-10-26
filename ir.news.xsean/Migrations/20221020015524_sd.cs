using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ir.news.xsean.Migrations
{
	public partial class sd : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "coment",
				table: "newsfi",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "datetime",
				table: "newsfi",
				type: "nvarchar(max)",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "like",
				table: "newsfi",
				type: "int",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "seen",
				table: "newsfi",
				type: "int",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "coment",
				table: "newsfi");

			migrationBuilder.DropColumn(
				name: "datetime",
				table: "newsfi");

			migrationBuilder.DropColumn(
				name: "like",
				table: "newsfi");

			migrationBuilder.DropColumn(
				name: "seen",
				table: "newsfi");
		}
	}
}
