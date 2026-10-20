using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymSystem.Datos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    NumeroCedula = table.Column<string>(type: "varchar(20)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: true),
                    Direccion = table.Column<string>(type: "varchar(200)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__D5946642B9512E68", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    IdPlan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    DuracionDias = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(250)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Planes__FB8102AE5824C7CF", x => x.IdPlan);
                    table.CheckConstraint("CK_Planes_Duracion", "([DuracionDias]>(0))");
                    table.CheckConstraint("CK_Planes_Precio", "([Precio]>(0))");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(50)", nullable: false),
                    ClaveHash = table.Column<string>(type: "varchar(255)", nullable: false),
                    Rol = table.Column<string>(type: "varchar(20)", nullable: false, defaultValue: "Empleado"),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__5B65BF97F74D9F6D", x => x.IdUsuario);
                    table.CheckConstraint("CK_Usuarios_Rol", "([Rol]='Empleado' OR [Rol]='Administrador')");
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    IdInscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdPlan = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    FechaFin = table.Column<DateTime>(type: "date", nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", nullable: false, defaultValue: "Activa")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inscripc__A122F2BF15483972", x => x.IdInscripcion);
                    table.CheckConstraint("CK_Inscripciones_Estado", "([Estado]='Cancelada' OR [Estado]='Vencida' OR [Estado]='Activa')");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Clientes",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Planes",
                        column: x => x.IdPlan,
                        principalTable: "Planes",
                        principalColumn: "IdPlan");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdInscripcion = table.Column<int>(type: "int", nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "GETDATE()"),
                    MetodoPago = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pagos__FC851A3AE7A63819", x => x.IdPago);
                    table.CheckConstraint("CK_Pagos_Metodo", "([MetodoPago]='Transferencia' OR [MetodoPago]='Tarjeta' OR [MetodoPago]='Efectivo')");
                    table.CheckConstraint("CK_Pagos_Monto", "([Monto]>(0))");
                    table.ForeignKey(
                        name: "FK_Pagos_Clientes",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones",
                        column: x => x.IdInscripcion,
                        principalTable: "Inscripciones",
                        principalColumn: "IdInscripcion");
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Clientes_Cedula",
                table: "Clientes",
                column: "NumeroCedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Clientes_Correo",
                table: "Clientes",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_IdCliente",
                table: "Inscripciones",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_IdPlan",
                table: "Inscripciones",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdCliente",
                table: "Pagos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdInscripcion",
                table: "Pagos",
                column: "IdInscripcion");

            migrationBuilder.CreateIndex(
                name: "UQ_Usuarios_Usuario",
                table: "Usuarios",
                column: "Usuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}
