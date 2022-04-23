using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductApi.Migrations
{
    public partial class DatabaseInitialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReplacedParts",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    product_name = table.Column<string>(maxLength: 60, nullable: false),
                    price = table.Column<double>(nullable: false),
                    product_description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacedParts", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReplacedParts");
        }
    }
}
