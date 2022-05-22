using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairApi.Migrations
{
    public partial class UpdateRepairModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "master_id",
                table: "Repairs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "master_id",
                table: "Repairs");
        }
    }
}
