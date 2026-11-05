using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sac");

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                schema: "sac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Nome do colaborador"),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Email do colaborador"),
                    Cargo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "Cargo do colaborador"),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, comment: "Telefone do colaborador"),
                    Admissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Data de admissão do colaborador"),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false, comment: "Indica se o colaborador está ativo ou não"),
                    Created_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                },
                comment: "Tabela de colaboradores da empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_Nome",
                schema: "sac",
                table: "Colaboradores",
                column: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores",
                schema: "sac");
        }
    }
}
