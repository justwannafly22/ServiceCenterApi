using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterApi.Migrations
{
    public partial class InitialisationMasterApi : Migration
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
                    contact_number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masters");
        }
    }
}
