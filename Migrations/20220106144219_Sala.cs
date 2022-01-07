using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_AVA_Proiect.Migrations
{
    public partial class Sala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaID",
                table: "Programare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numar = table.Column<int>(type: "int", nullable: false),
                    Etaj = table.Column<int>(type: "int", nullable: false),
                    Strada = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_SalaID",
                table: "Programare",
                column: "SalaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Programare_Sala_SalaID",
                table: "Programare",
                column: "SalaID",
                principalTable: "Sala",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programare_Sala_SalaID",
                table: "Programare");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Programare_SalaID",
                table: "Programare");

            migrationBuilder.DropColumn(
                name: "SalaID",
                table: "Programare");
        }
    }
}
