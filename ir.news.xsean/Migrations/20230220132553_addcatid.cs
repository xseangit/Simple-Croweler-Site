using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ir.news.xsean.Migrations
{
    public partial class addcatid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_newsfi_catgories_Catgoryid",
                table: "newsfi");

            migrationBuilder.DropForeignKey(
                name: "FK_newss_catgories_Catgoryid",
                table: "newss");

            migrationBuilder.AlterColumn<int>(
                name: "Catgoryid",
                table: "newss",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Catgoryid",
                table: "newsfi",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_newsfi_catgories_Catgoryid",
                table: "newsfi",
                column: "Catgoryid",
                principalTable: "catgories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_newss_catgories_Catgoryid",
                table: "newss",
                column: "Catgoryid",
                principalTable: "catgories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_newsfi_catgories_Catgoryid",
                table: "newsfi");

            migrationBuilder.DropForeignKey(
                name: "FK_newss_catgories_Catgoryid",
                table: "newss");

            migrationBuilder.AlterColumn<int>(
                name: "Catgoryid",
                table: "newss",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Catgoryid",
                table: "newsfi",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
