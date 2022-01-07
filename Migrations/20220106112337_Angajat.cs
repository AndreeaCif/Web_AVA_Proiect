using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_AVA_Proiect.Migrations
{
    public partial class Angajat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AngajatID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nr_telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salariu = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_AngajatID",
                table: "Programare",
                column: "AngajatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Angajat_AngajatID",
                table: "Programare",
                column: "AngajatID",
                principalTable: "Angajat",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Angajat_AngajatID",
                table: "Programare");

            migrationBuilder.DropTable(
                name: "Angajat");

            migrationBuilder.DropIndex(
                name: "IX_Programare_AngajatID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "AngajatID",
                table: "Programare");
        }
    }
}
