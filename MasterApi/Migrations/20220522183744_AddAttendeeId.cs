using Microsoft.EntityFrameworkCore.Migrations;

namespace MasterApi.Migrations
{
    public partial class AddAttendeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "attendee_id",
                table: "Masters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "attendee_id",
                table: "Masters");
        }
    }
}
