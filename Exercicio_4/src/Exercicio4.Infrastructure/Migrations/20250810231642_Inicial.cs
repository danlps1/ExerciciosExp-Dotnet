using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Exercicio4.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    GradeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_alunos_tb_grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "tb_grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_gradeMaterias",
                columns: table => new
                {
                    GradesId = table.Column<int>(type: "integer", nullable: false),
                    MateriasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_gradeMaterias", x => new { x.GradesId, x.MateriasId });
                    table.ForeignKey(
                        name: "FK_tb_gradeMaterias_tb_grades_GradesId",
                        column: x => x.GradesId,
                        principalTable: "tb_grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_gradeMaterias_tb_materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "tb_materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlunoId = table.Column<int>(type: "integer", nullable: false),
                    MateriaId = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_notas_tb_alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "tb_alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_notas_tb_materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "tb_materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_alunos_GradeId",
                table: "tb_alunos",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_gradeMaterias_MateriasId",
                table: "tb_gradeMaterias",
                column: "MateriasId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_notas_AlunoId",
                table: "tb_notas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_notas_MateriaId",
                table: "tb_notas",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_gradeMaterias");

            migrationBuilder.DropTable(
                name: "tb_notas");

            migrationBuilder.DropTable(
                name: "tb_alunos");

            migrationBuilder.DropTable(
                name: "tb_materias");

            migrationBuilder.DropTable(
                name: "tb_grades");
        }
    }
}
