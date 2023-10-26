using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ir.news.xsean.Migrations
{
	public partial class start : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "catgories",
				columns: table => new
				{
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
					count = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_catgories", x => x.Name);
				});

			migrationBuilder.CreateTable(
				name: "urlscros",
				columns: table => new
				{
					url = table.Column<string>(type: "nvarchar(450)", nullable: false),
					crowel = table.Column<bool>(type: "bit", nullable: false),
					bad = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_urlscros", x => x.url);
				});

			migrationBuilder.CreateTable(
				name: "newss",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false),
					url = table.Column<string>(type: "nvarchar(450)", nullable: false),
					site = table.Column<string>(type: "nvarchar(max)", nullable: true),
					titleimg = table.Column<string>(type: "nvarchar(max)", nullable: true),
					titleimgdo = table.Column<string>(type: "nvarchar(max)", nullable: true),
					title = table.Column<string>(type: "nvarchar(max)", nullable: true),
					news = table.Column<string>(type: "nvarchar(max)", nullable: true),
					newser = table.Column<string>(type: "nvarchar(max)", nullable: true),
					datetime = table.Column<string>(type: "nvarchar(max)", nullable: true),
					shorts = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CatgoryName = table.Column<string>(type: "nvarchar(450)", nullable: true),
					seen = table.Column<int>(type: "int", nullable: true),
					like = table.Column<int>(type: "int", nullable: true),
					InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
					IsRemoved = table.Column<bool>(type: "bit", nullable: false),
					RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_newss", x => x.Id);
					table.ForeignKey(
						name: "FK_newss_catgories_CatgoryName",
						column: x => x.CatgoryName,
						principalTable: "catgories",
						principalColumn: "Name");
				});

			migrationBuilder.CreateTable(
				name: "coment",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false),
					newsId = table.Column<long>(type: "bigint", nullable: true),
					name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					com = table.Column<string>(type: "nvarchar(max)", nullable: false),
					InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
					IsRemoved = table.Column<bool>(type: "bit", nullable: false),
					RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_coment", x => x.Id);
					table.ForeignKey(
						name: "FK_coment_newss_newsId",
						column: x => x.newsId,
						principalTable: "newss",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_coment_newsId",
				table: "coment",
				column: "newsId");

			migrationBuilder.CreateIndex(
				name: "IX_newss_CatgoryName",
				table: "newss",
				column: "CatgoryName");

			migrationBuilder.CreateIndex(
				name: "IX_newss_url",
				table: "newss",
				column: "url",
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "coment");

			migrationBuilder.DropTable(
				name: "urlscros");

			migrationBuilder.DropTable(
				name: "newss");

			migrationBuilder.DropTable(
				name: "catgories");
		}
	}
}
