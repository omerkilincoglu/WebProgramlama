using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B201210597.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Kullanici_KullaniciId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullanici",
                table: "Kullanici");

            migrationBuilder.RenameTable(
                name: "Kullanici",
                newName: "Kullaniciler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullaniciler",
                table: "Kullaniciler",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Kullaniciler_KullaniciId",
                table: "Appointments",
                column: "KullaniciId",
                principalTable: "Kullaniciler",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Kullaniciler_KullaniciId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kullaniciler",
                table: "Kullaniciler");

            migrationBuilder.RenameTable(
                name: "Kullaniciler",
                newName: "Kullanici");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kullanici",
                table: "Kullanici",
                column: "KullaniciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Kullanici_KullaniciId",
                table: "Appointments",
                column: "KullaniciId",
                principalTable: "Kullanici",
                principalColumn: "KullaniciId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
