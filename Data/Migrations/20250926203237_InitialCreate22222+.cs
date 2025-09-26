using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate22222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(360)", maxLength: 360, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.IdEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    IdPlan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(360)", maxLength: 360, nullable: false),
                    IdEspecialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.IdPlan);
                    table.ForeignKey(
                        name: "FK_Planes_Especialidades_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidades",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comisiones",
                columns: table => new
                {
                    IdComision = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnioEspecialidad = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdPlan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comisiones", x => x.IdComision);
                    table.ForeignKey(
                        name: "FK_Comisiones_Planes_IdPlan",
                        column: x => x.IdPlan,
                        principalTable: "Planes",
                        principalColumn: "IdPlan",
                        onDelete: ReferentialAction.Cascade);
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
                    IdPlan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.IdMateria);
                    table.ForeignKey(
                        name: "FK_Materias_Planes_IdPlan",
                        column: x => x.IdPlan,
                        principalTable: "Planes",
                        principalColumn: "IdPlan",
                        onDelete: ReferentialAction.Cascade);
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
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Legajo = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TipoPersona = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdPlan = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Personas_Planes_IdPlan",
                        column: x => x.IdPlan,
                        principalTable: "Planes",
                        principalColumn: "IdPlan",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Cursos_Comisiones_IdComision",
                        column: x => x.IdComision,
                        principalTable: "Comisiones",
                        principalColumn: "IdComision",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cursos_Materias_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Materias",
                        principalColumn: "IdMateria",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "IdEspecialidad", "Descripcion" },
                values: new object[] { 1, "Especialidad" });

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "IdPlan", "Descripcion", "IdEspecialidad" },
                values: new object[] { 1, "Plan básico", 1 });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "IdPersona", "Apellido", "Direccion", "Email", "FechaNacimiento", "IdPlan", "Legajo", "Telefono", "TipoPersona" },
                values: new object[] { 1, "Admin", "Admin 123", "admin@gmail.com", new DateTime(2004, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1234, "3419999999", "no se" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellido", "CambiaClave", "Clave", "Email", "Habilitado", "IdPersona", "Nombre", "NombreUsuario" },
                values: new object[] { 1, "Admin", false, "1234", "admin@gmail.com", true, 1, "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_IdComision",
                table: "Comisiones",
                column: "IdComision",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_IdPlan",
                table: "Comisiones",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdComision",
                table: "Cursos",
                column: "IdComision");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdMateria",
                table: "Cursos",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_IdEspecialidad",
                table: "Especialidades",
                column: "IdEspecialidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_IdMateria",
                table: "Materias",
                column: "IdMateria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materias_IdPlan",
                table: "Materias",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdPersona",
                table: "Personas",
                column: "IdPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdPlan",
                table: "Personas",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_IdEspecialidad",
                table: "Planes",
                column: "IdEspecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_IdPlan",
                table: "Planes",
                column: "IdPlan",
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

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
