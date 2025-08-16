using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewsToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.CreateTable(
            //    name: "News",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        Writer = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Title = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        Description = table.Column<string>(type: "longtext", nullable: false)
            //            .Annotation("MySql:CharSet", "utf8mb4"),
            //        PostDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
            //        ReadCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_News", x => x.Id);
            //    })
            //    .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
