using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientApi.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    client_name = table.Column<string>(nullable: false),
                    client_surname = table.Column<string>(nullable: false),
                    age = table.Column<int>(nullable: false),
                    contact_number = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    allow_email_notifications = table.Column<bool>(nullable: false),
                    user_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
