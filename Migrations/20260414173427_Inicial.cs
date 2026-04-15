using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delivery.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ci = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoComida = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repartidores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacaVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repartidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Locales_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepartidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Repartidores_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecargoVip = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TiempoEstimadoMinutos = table.Column<int>(type: "int", nullable: false),
                    TipoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepartidorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vips_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vips_Repartidores_RepartidorId",
                        column: x => x.RepartidorId,
                        principalTable: "Repartidores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_PedidoId",
                table: "DetallePedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_ProductoId",
                table: "DetallePedidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_RepartidorId",
                table: "Pedidos",
                column: "RepartidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_LocalId",
                table: "Productos",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Vips_ClienteId",
                table: "Vips",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vips_RepartidorId",
                table: "Vips",
                column: "RepartidorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "Vips");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Repartidores");

            migrationBuilder.DropTable(
                name: "Locales");
        }
    }
}
