using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagement.Migrations
{
    public partial class Initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Designation_DesignationID",
                table: "EmployeeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Designation",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Designation");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationID",
                table: "Designation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designation",
                table: "Designation",
                column: "DesignationID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_Designation_DesignationID",
                table: "EmployeeDetails",
                column: "DesignationID",
                principalTable: "Designation",
                principalColumn: "DesignationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_Designation_DesignationID",
                table: "EmployeeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Designation",
                table: "Designation");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationID",
                table: "Designation",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Designation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designation",
                table: "Designation",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_Designation_DesignationID",
                table: "EmployeeDetails",
                column: "DesignationID",
                principalTable: "Designation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
