using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ir.news.xsean.Migrations
{
	public partial class sec : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "newsfi",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false),
					url = table.Column<string>(type: "nvarchar(max)", nullable: false),
					CatgoryName = table.Column<string>(type: "nvarchar(450)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_newsfi", x => x.Id);
					table.ForeignKey(
						name: "FK_newsfi_catgories_CatgoryName",
						column: x => x.CatgoryName,
						principalTable: "catgories",
						principalColumn: "Name");
				});

			migrationBuilder.CreateIndex(
				name: "IX_newsfi_CatgoryName",
				table: "newsfi",
				column: "CatgoryName");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "newsfi");
		}
	}
}
