using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechademyEmployeeManagement.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    DesignationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.DesignationID);
                });

            migrationBuilder.CreateTable(
                name: "employeeDTOs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DesignationID = table.Column<int>(nullable: false),
                    DesignationName = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    MemberSince = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeDTOs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DesignationID = table.Column<int>(nullable: false),
                    MemberSince = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Designation_DesignationID",
                        column: x => x.DesignationID,
                        principalTable: "Designation",
                        principalColumn: "DesignationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_DesignationID",
                table: "EmployeeDetails",
                column: "DesignationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "employeeDTOs");

            migrationBuilder.DropTable(
                name: "Designation");
        }
    }
}
