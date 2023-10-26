using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ir.news.xsean.Migrations
{
	public partial class secend : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_newsfi_catgories_CatgoryName",
				table: "newsfi");

			migrationBuilder.DropForeignKey(
				name: "FK_newss_catgories_CatgoryName",
				table: "newss");

			migrationBuilder.DropIndex(
				name: "IX_newss_CatgoryName",
				table: "newss");

			migrationBuilder.DropIndex(
				name: "IX_newsfi_CatgoryName",
				table: "newsfi");

			migrationBuilder.DropPrimaryKey(
				name: "PK_catgories",
				table: "catgories");

			migrationBuilder.AlterColumn<string>(
				name: "CatgoryName",
				table: "newss",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "Catgoryid",
				table: "newss",
				type: "int",
				nullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "CatgoryName",
				table: "newsfi",
				type: "nvarchar(max)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)",
				oldNullable: true);

			migrationBuilder.AddColumn<int>(
				name: "Catgoryid",
				table: "newsfi",
				type: "int",
				nullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "catgories",
				type: "nvarchar(max)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(450)");

			migrationBuilder.AddColumn<int>(
				name: "id",
				table: "catgories",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddPrimaryKey(
				name: "PK_catgories",
				table: "catgories",
				column: "id");

			migrationBuilder.CreateIndex(
				name: "IX_newss_Catgoryid",
				table: "newss",
				column: "Catgoryid");

			migrationBuilder.CreateIndex(
				name: "IX_newsfi_Catgoryid",
				table: "newsfi",
				column: "Catgoryid");

			migrationBuilder.AddForeignKey(
				name: "FK_newsfi_catgories_Catgoryid",
				table: "newsfi",
				column: "Catgoryid",
				principalTable: "catgories",
				principalColumn: "id");

			migrationBuilder.AddForeignKey(
				name: "FK_newss_catgories_Catgoryid",
				table: "newss",
				column: "Catgoryid",
				principalTable: "catgories",
				principalColumn: "id");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_newsfi_catgories_Catgoryid",
				table: "newsfi");

			migrationBuilder.DropForeignKey(
				name: "FK_newss_catgories_Catgoryid",
				table: "newss");

			migrationBuilder.DropIndex(
				name: "IX_newss_Catgoryid",
				table: "newss");

			migrationBuilder.DropIndex(
				name: "IX_newsfi_Catgoryid",
				table: "newsfi");

			migrationBuilder.DropPrimaryKey(
				name: "PK_catgories",
				table: "catgories");

			migrationBuilder.DropColumn(
				name: "Catgoryid",
				table: "newss");

			migrationBuilder.DropColumn(
				name: "Catgoryid",
				table: "newsfi");

			migrationBuilder.DropColumn(
				name: "id",
				table: "catgories");

			migrationBuilder.AlterColumn<string>(
				name: "CatgoryName",
				table: "newss",
				type: "nvarchar(450)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "CatgoryName",
				table: "newsfi",
				type: "nvarchar(450)",
				nullable: true,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)",
				oldNullable: true);

			migrationBuilder.AlterColumn<string>(
				name: "Name",
				table: "catgories",
				type: "nvarchar(450)",
				nullable: false,
				oldClrType: typeof(string),
				oldType: "nvarchar(max)");

			migrationBuilder.AddPrimaryKey(
				name: "PK_catgories",
				table: "catgories",
				column: "Name");

			migrationBuilder.CreateIndex(
				name: "IX_newss_CatgoryName",
				table: "newss",
				column: "CatgoryName");

			migrationBuilder.CreateIndex(
				name: "IX_newsfi_CatgoryName",
				table: "newsfi",
				column: "CatgoryName");

			migrationBuilder.AddForeignKey(
				name: "FK_newsfi_catgories_CatgoryName",
				table: "newsfi",
				column: "CatgoryName",
				principalTable: "catgories",
				principalColumn: "Name");

			migrationBuilder.AddForeignKey(
				name: "FK_newss_catgories_CatgoryName",
				table: "newss",
				column: "CatgoryName",
				principalTable: "catgories",
				principalColumn: "Name");
		}
	}
}
