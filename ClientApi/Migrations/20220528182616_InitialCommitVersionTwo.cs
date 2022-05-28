using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientApi.Migrations
{
    public partial class InitialCommitVersionTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    master_name = table.Column<string>(maxLength: 60, nullable: false),
                    master_surname = table.Column<string>(maxLength: 60, nullable: false),
                    age = table.Column<int>(nullable: false),
                    contact_number = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    attendee_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    product_name = table.Column<string>(maxLength: 60, nullable: false),
                    product_description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 60, nullable: false),
                    repairinfo_id = table.Column<Guid>(nullable: false),
                    client_id = table.Column<Guid>(nullable: false),
                    product_id = table.Column<Guid>(nullable: false),
                    master_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    status_info = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RepairsInfo",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    repair_date = table.Column<DateTime>(nullable: false),
                    advanced_info = table.Column<string>(maxLength: 500, nullable: false),
                    status_id = table.Column<Guid>(nullable: false),
                    repair_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairsInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_RepairsInfo_Repairs_repair_id",
                        column: x => x.repair_id,
                        principalTable: "Repairs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairsInfo_Statuses_status_id",
                        column: x => x.status_id,
                        principalTable: "Statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairsInfo_repair_id",
                table: "RepairsInfo",
                column: "repair_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairsInfo_status_id",
                table: "RepairsInfo",
                column: "status_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masters");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RepairsInfo");

            migrationBuilder.DropTable(
                name: "ReplacedParts");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
