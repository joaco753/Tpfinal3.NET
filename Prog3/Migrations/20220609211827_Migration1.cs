using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prog3.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    idPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RazonSocial = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.idPersona);
                });

            migrationBuilder.CreateTable(
                name: "TipoProducto",
                columns: table => new
                {
                    idTipoProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProducto", x => x.idTipoProducto);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                    table.ForeignKey(
                        name: "fk_cliente_idpersona",
                        column: x => x.idPersona,
                        principalTable: "Persona",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    idDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    Provincia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Calle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NumeroCalle = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.idDireccion);
                    table.ForeignKey(
                        name: "fk_direccion_idpersona",
                        column: x => x.idPersona,
                        principalTable: "Persona",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    idProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    Rubro = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.idProveedor);
                    table.ForeignKey(
                        name: "fk_proveedor_idpersona",
                        column: x => x.idPersona,
                        principalTable: "Persona",
                        principalColumn: "idPersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    idProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipoProducto = table.Column<int>(type: "int", nullable: true),
                    CodigoProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: true),
                    NombreProducto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: true),
                    Imagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.idProducto);
                    table.ForeignKey(
                        name: "fk_producto_idtipoproducto",
                        column: x => x.idTipoProducto,
                        principalTable: "TipoProducto",
                        principalColumn: "idTipoProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    idVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    Sucursal = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    TotalVenta = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1", x => x.idVenta);
                    table.ForeignKey(
                        name: "fk_venta_idcliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    idCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProveedor = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: true),
                    TotalCompra = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.idCompra);
                    table.ForeignKey(
                        name: "fk_compra_idproveedor",
                        column: x => x.idProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "idProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    idDetalleVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idVenta = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    recargo = table.Column<double>(type: "float", nullable: true),
                    descuento = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.idDetalleVenta);
                    table.ForeignKey(
                        name: "fk_detalleventa_idproducto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_detalleventa_idventa",
                        column: x => x.idVenta,
                        principalTable: "Venta",
                        principalColumn: "idVenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                columns: table => new
                {
                    idDetalleCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCompra = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompra", x => x.idDetalleCompra);
                    table.ForeignKey(
                        name: "fk_detallecompra_idcompra",
                        column: x => x.idCompra,
                        principalTable: "Compra",
                        principalColumn: "idCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_detallecompra_idproducto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_idPersona",
                table: "Cliente",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_idProveedor",
                table: "Compra",
                column: "idProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_idCompra",
                table: "DetalleCompra",
                column: "idCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_idProducto",
                table: "DetalleCompra",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_idProducto",
                table: "DetalleVenta",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_idVenta",
                table: "DetalleVenta",
                column: "idVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_idPersona",
                table: "Direccion",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_idTipoProducto",
                table: "Producto",
                column: "idTipoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_idPersona",
                table: "Proveedor",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_idCliente",
                table: "Venta",
                column: "idCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCompra");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "TipoProducto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
