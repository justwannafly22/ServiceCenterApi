using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientApi.Migrations
{
    public partial class AddAttendeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "master_id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "attendee_id",
                table: "Clients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "attendee_id",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "master_id",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
