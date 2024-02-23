using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturacionWeb.Migrations
{
    /// <inheritdoc />
    public partial class StartDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIT = table.Column<int>(type: "int", nullable: false),
                    NumeroFactura = table.Column<int>(type: "int", nullable: false),
                    AplicaDescuento = table.Column<int>(type: "int", nullable: false),
                    ValorDescuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Auditorias_Facturas_CodigoFactura",
                        column: x => x.CodigoFactura,
                        principalTable: "Facturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturas",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescuentoProducto = table.Column<double>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ValorRegistro = table.Column<int>(type: "int", nullable: false),
                    CodigoFactura = table.Column<int>(type: "int", nullable: false),
                    CodigoProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Facturas_CodigoFactura",
                        column: x => x.CodigoFactura,
                        principalTable: "Facturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleFacturas_Productos_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_CodigoFactura",
                table: "Auditorias",
                column: "CodigoFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_CodigoFactura",
                table: "DetalleFacturas",
                column: "CodigoFactura");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturas_CodigoProducto",
                table: "DetalleFacturas",
                column: "CodigoProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "DetalleFacturas");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
