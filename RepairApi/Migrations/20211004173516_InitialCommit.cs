using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairApi.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 60, nullable: false),
                    repairinfo_id = table.Column<Guid>(nullable: false),
                    client_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.id);
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
                name: "RepairsInfo");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
