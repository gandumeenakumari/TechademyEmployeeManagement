using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagement.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requestLeaves_EmployeeDetails_EmployeeDetailsEmployeeID",
                table: "requestLeaves");

            migrationBuilder.DropIndex(
                name: "IX_requestLeaves_EmployeeDetailsEmployeeID",
                table: "requestLeaves");

            migrationBuilder.DropColumn(
                name: "EmployeeDetailsEmployeeID",
                table: "requestLeaves");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeDetailsEmployeeID",
                table: "requestLeaves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_requestLeaves_EmployeeDetailsEmployeeID",
                table: "requestLeaves",
                column: "EmployeeDetailsEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_requestLeaves_EmployeeDetails_EmployeeDetailsEmployeeID",
                table: "requestLeaves",
                column: "EmployeeDetailsEmployeeID",
                principalTable: "EmployeeDetails",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
