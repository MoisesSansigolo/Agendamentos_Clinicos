using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Agendamentos_Clinicos.Migrations
{
    public partial class CriandoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_especialidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    ativa = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_especialidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    celular = table.Column<string>(type: "varchar(100)", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_paciente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_profissional",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_profissional", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadeProfissional",
                columns: table => new
                {
                    EspecialidadesId = table.Column<int>(type: "integer", nullable: false),
                    ProfissionaisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeProfissional", x => new { x.EspecialidadesId, x.ProfissionaisId });
                    table.ForeignKey(
                        name: "FK_EspecialidadeProfissional_tb_especialidade_EspecialidadesId",
                        column: x => x.EspecialidadesId,
                        principalTable: "tb_especialidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EspecialidadeProfissional_tb_profissional_ProfissionaisId",
                        column: x => x.ProfissionaisId,
                        principalTable: "tb_profissional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_consulta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_horario = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    preco = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "integer", nullable: false),
                    ProfissionalId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_consulta", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_consulta_tb_especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "tb_especialidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_consulta_tb_paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "tb_paciente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_consulta_tb_profissional_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "tb_profissional",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadeProfissional_ProfissionaisId",
                table: "EspecialidadeProfissional",
                column: "ProfissionaisId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_EspecialidadeId",
                table: "tb_consulta",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_PacienteId",
                table: "tb_consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_ProfissionalId",
                table: "tb_consulta",
                column: "ProfissionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspecialidadeProfissional");

            migrationBuilder.DropTable(
                name: "tb_consulta");

            migrationBuilder.DropTable(
                name: "tb_especialidade");

            migrationBuilder.DropTable(
                name: "tb_paciente");

            migrationBuilder.DropTable(
                name: "tb_profissional");
        }
    }
}
