using Microsoft.EntityFrameworkCore.Migrations;

namespace Agendamentos_Clinicos.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "tb_consulta",
                newName: "id_paciente");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_PacienteId",
                table: "tb_consulta",
                newName: "IX_tb_consulta_id_paciente");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "id_paciente",
                table: "tb_consulta",
                newName: "PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "tb_consulta",
                newName: "IX_tb_consulta_PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta",
                column: "PacienteId",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
