using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientApi.Migrations
{
    public partial class ChangeEntityFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "allow_email_notifications",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "master_id",
                table: "Clients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "master_id",
                table: "Clients");

            migrationBuilder.AddColumn<bool>(
                name: "allow_email_notifications",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
