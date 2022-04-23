using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductApi.Migrations
{
    public partial class UpdateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReplacedParts",
                table: "ReplacedParts");

            migrationBuilder.RenameTable(
                name: "ReplacedParts",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ReplacedParts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReplacedParts",
                table: "ReplacedParts",
                column: "id");
        }
    }
}
