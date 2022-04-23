using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReplacedPartApi.Migrations
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
                    replaced_part_name = table.Column<string>(maxLength: 60, nullable: false),
                    price = table.Column<double>(nullable: false),
                    replaced_part_count = table.Column<int>(nullable: false),
                    advanced_info = table.Column<string>(maxLength: 500, nullable: false),
                    repair_id = table.Column<Guid>(nullable: false),
                    product_id = table.Column<Guid>(nullable: false)
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
