using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagement.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_requestLeaves",
                table: "requestLeaves");

            migrationBuilder.RenameTable(
                name: "requestLeaves",
                newName: "RequestLeave");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestLeave",
                table: "RequestLeave",
                column: "LeaveID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestLeave",
                table: "RequestLeave");

            migrationBuilder.RenameTable(
                name: "RequestLeave",
                newName: "requestLeaves");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requestLeaves",
                table: "requestLeaves",
                column: "LeaveID");
        }
    }
}
