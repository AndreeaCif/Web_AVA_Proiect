using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_AVA_Proiect.Migrations
{
    public partial class MasajCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masaj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masaj", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MasajCategorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramareID = table.Column<int>(type: "int", nullable: false),
                    MasajID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasajCategorie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MasajCategorie_Masaj_MasajID",
                        column: x => x.MasajID,
                        principalTable: "Masaj",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MasajCategorie_Programare_ProgramareID",
                        column: x => x.ProgramareID,
                        principalTable: "Programare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasajCategorie_MasajID",
                table: "MasajCategorie",
                column: "MasajID");

            migrationBuilder.CreateIndex(
                name: "IX_MasajCategorie_ProgramareID",
                table: "MasajCategorie",
                column: "ProgramareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasajCategorie");

            migrationBuilder.DropTable(
                name: "Masaj");
        }
    }
}
