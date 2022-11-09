using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagement.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestLeave",
                table: "RequestLeave");

            migrationBuilder.DropColumn(
                name: "LeaveID",
                table: "RequestLeave");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "RequestLeave");

            migrationBuilder.DropColumn(
                name: "LeaveStatus",
                table: "RequestLeave");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "RequestLeave",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestLeave",
                table: "RequestLeave",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "LeaveStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveStatus", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestLeave",
                table: "RequestLeave");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "RequestLeave");

            migrationBuilder.AddColumn<int>(
                name: "LeaveID",
                table: "RequestLeave",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "RequestLeave",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LeaveStatus",
                table: "RequestLeave",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestLeave",
                table: "RequestLeave",
                column: "LeaveID");
        }
    }
}
