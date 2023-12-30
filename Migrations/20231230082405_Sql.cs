using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B201210597.Migrations
{
    public partial class Sql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ClinicId",
                table: "Departments",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Clinics_ClinicId",
                table: "Departments",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "ClinicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Clinics_ClinicId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ClinicId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Departments");
        }
    }
}
