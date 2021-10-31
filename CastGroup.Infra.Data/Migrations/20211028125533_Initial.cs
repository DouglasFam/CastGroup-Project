using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastGroup.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CST_CATEGORIAS",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CST_CATEGORIAS", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "CST_CURSOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime", nullable: false),
                    QuantidadeAlunos = table.Column<int>(type: "int", nullable: false),
                    CodigoCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CST_CURSOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CST_CURSOS_CST_CATEGORIAS_CodigoCategoria",
                        column: x => x.CodigoCategoria,
                        principalTable: "CST_CATEGORIAS",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CST_CURSOS_CodigoCategoria",
                table: "CST_CURSOS",
                column: "CodigoCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CST_CURSOS");

            migrationBuilder.DropTable(
                name: "CST_CATEGORIAS");
        }
    }
}
