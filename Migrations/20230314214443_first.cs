using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctores",
                columns: table => new
                {
                    NMatricula = table.Column<Guid>(type: "uuid", nullable: false),
                    Especialidad = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctores", x => x.NMatricula);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    H_Clinica = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.H_Clinica);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ConsultaId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Costo = table.Column<int>(type: "integer", nullable: false),
                    CostoMateriales = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    PacienteH_Clinica = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteH_Clinica",
                        column: x => x.PacienteH_Clinica,
                        principalTable: "Pacientes",
                        principalColumn: "H_Clinica");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteH_Clinica",
                table: "Consultas",
                column: "PacienteH_Clinica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Doctores");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
