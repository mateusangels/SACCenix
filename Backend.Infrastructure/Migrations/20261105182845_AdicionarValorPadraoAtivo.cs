using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarValorPadraoAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                schema: "sac",
                table: "Colaboradores",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                comment: "Indica se o colaborador está ativo ou não",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "Indica se o colaborador está ativo ou não");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                schema: "sac",
                table: "Colaboradores",
                type: "boolean",
                nullable: false,
                comment: "Indica se o colaborador está ativo ou não",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true,
                oldComment: "Indica se o colaborador está ativo ou não");
        }
    }
}
