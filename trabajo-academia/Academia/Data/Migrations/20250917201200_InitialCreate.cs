using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comisiones",
                columns: table => new
                {
                    IdComision = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnioEspecialidad = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdPlan = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comisiones", x => x.IdComision);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    IdMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HsSemanales = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    HsTotales = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    IdPlan = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.IdMateria);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: false),
                    IdPlan = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Legajo = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TipoPersona = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnioCalendario = table.Column<int>(type: "int", nullable: false),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    IdComision = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK_Cursos_Comisiones_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Comisiones",
                        principalColumn: "IdComision",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cursos_Materias_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Materias",
                        principalColumn: "IdMateria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CambiaClave = table.Column<bool>(type: "bit", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_IdComision",
                table: "Comisiones",
                column: "IdComision",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdMateria",
                table: "Cursos",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_IdMateria",
                table: "Materias",
                column: "IdMateria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdPersona",
                table: "Personas",
                column: "IdPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPersona",
                table: "Usuarios",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdUsuario",
                table: "Usuarios",
                column: "IdUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Comisiones");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
