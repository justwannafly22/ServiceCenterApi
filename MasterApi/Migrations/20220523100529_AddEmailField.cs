using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterApi.Migrations
{
    public partial class AddEmailField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "attendee_id",
                table: "Masters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Masters",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Masters");

            migrationBuilder.AlterColumn<string>(
                name: "attendee_id",
                table: "Masters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));
        }
    }
}
