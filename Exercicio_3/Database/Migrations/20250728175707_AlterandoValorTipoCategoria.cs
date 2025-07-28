using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio_3.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoValorTipoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoCategoria",
                table: "tb_categorias",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoCategoria",
                table: "tb_categorias",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
