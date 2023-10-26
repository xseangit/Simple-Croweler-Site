using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ir.news.xsean.Migrations
{
	public partial class sec2 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateTime>(
				name: "InsertTime",
				table: "newsfi",
				type: "datetime2",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

			migrationBuilder.AddColumn<bool>(
				name: "IsRemoved",
				table: "newsfi",
				type: "bit",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<DateTime>(
				name: "RemoveTime",
				table: "newsfi",
				type: "datetime2",
				nullable: true);

			migrationBuilder.AddColumn<DateTime>(
				name: "UpdateTime",
				table: "newsfi",
				type: "datetime2",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "InsertTime",
				table: "newsfi");

			migrationBuilder.DropColumn(
				name: "IsRemoved",
				table: "newsfi");

			migrationBuilder.DropColumn(
				name: "RemoveTime",
				table: "newsfi");

			migrationBuilder.DropColumn(
				name: "UpdateTime",
				table: "newsfi");
		}
	}
}
