using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Repository.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__CD54BC5A6BF18FFC", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_completo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    correo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    clave = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    rol = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuarios__4E3E04AD144EADEA", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    descripcion = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    id_categoria = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    precio_oferta = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    imagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__FF341C0D1F5C0232", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK__Productos__id_ca__3A81B327",
                        column: x => x.id_categoria,
                        principalTable: "Categorias",
                        principalColumn: "id_categoria");
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    id_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario = table.Column<int>(type: "int", nullable: true),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ventas__459533BF26135A19", x => x.id_venta);
                    table.ForeignKey(
                        name: "FK__Ventas__id_usuar__412EB0B6",
                        column: x => x.id_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Venta",
                columns: table => new
                {
                    id_detalle_Venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_venta = table.Column<int>(type: "int", nullable: true),
                    id_producto = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Detalle___4E17E5257A3A5682", x => x.id_detalle_Venta);
                    table.ForeignKey(
                        name: "FK__Detalle_V__id_pr__45F365D3",
                        column: x => x.id_producto,
                        principalTable: "Productos",
                        principalColumn: "id_producto");
                    table.ForeignKey(
                        name: "FK__Detalle_V__id_ve__44FF419A",
                        column: x => x.id_venta,
                        principalTable: "Ventas",
                        principalColumn: "id_venta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Venta_id_producto",
                table: "Detalle_Venta",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Venta_id_venta",
                table: "Detalle_Venta",
                column: "id_venta");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_id_categoria",
                table: "Productos",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Correo",
                table: "Usuarios",
                column: "correo");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_id_usuario",
                table: "Ventas",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Venta");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
