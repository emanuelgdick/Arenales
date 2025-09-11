using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class uno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<long>(type: "bigint", nullable: false),
                    FechaApertura = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdVendedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClienteCuentaCorriente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    EstadoCuentaCorriente = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    FechaUltimoPago = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClienteC__3214EC07613E6B20", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CondicionIva",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Condicio__3214EC079E0B9F5A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCarrito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCarrito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCredito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCredito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Impuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Alicuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Impuesto__3214EC0726ECC11F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iva",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<decimal>(type: "numeric(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NHibernateTest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "PreciosTable",
                columns: table => new
                {
                    CodigoBarras = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Costo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Precio = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PrecioSinIva = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Producto2",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    IdMarca = table.Column<long>(type: "bigint", nullable: false),
                    IdTalle = table.Column<long>(type: "bigint", nullable: false),
                    IdColor = table.Column<long>(type: "bigint", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CodigoBarras = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PrecioSinIva = table.Column<decimal>(type: "money", nullable: false),
                    Costo = table.Column<decimal>(type: "money", nullable: false),
                    IdImpuesto = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Calle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Cuit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Depto = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Piso = table.Column<int>(type: "int", nullable: true),
                    TelefonoFijo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TelefonoMovil = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Torre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorCuentaCorriente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    EstadoCuentaCorriente = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__3214EC073948E8D8", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorCuentaCorrienteMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedorCuentaCorriente = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdComprobante = table.Column<int>(type: "int", nullable: true),
                    Concepto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Debe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Haber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Vencimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__3214EC07F4CC4698", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EsCorriente = table.Column<bool>(type: "bit", nullable: true),
                    PathRemitos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PathPrecios = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Coneccion = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Mail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MailPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PathDownloads = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TalleCentral",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelo_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoComprobante",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Signo = table.Column<int>(type: "int", nullable: false),
                    Letra = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    EsFiscal = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoComp__3214EC07790560BE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Manual = table.Column<bool>(type: "bit", nullable: false),
                    Signo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimientoCaja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Signo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimientoCaja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApeyNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cheque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBanco = table.Column<int>(type: "int", nullable: true),
                    Sucursal = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FechaEmision = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaCobro = table.Column<DateTime>(type: "datetime", nullable: true),
                    EsPropio = table.Column<bool>(type: "bit", nullable: true),
                    ImporteCheque = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdPago = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheque_Banco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tarjetum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBanco = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Direccion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Cuit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true),
                    PathCertificado = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IdCondicionIva = table.Column<long>(type: "bigint", nullable: true),
                    PuntoVenta = table.Column<int>(type: "int", nullable: true),
                    FechaInicioActividades = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Sign = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Token = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ExpirationTime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PassCert = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Test = table.Column<bool>(type: "bit", nullable: true),
                    PathImagen = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetaCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarjetaCredito_Banco",
                        column: x => x.IdBanco,
                        principalTable: "Banco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Calle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Cuit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Depto = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Piso = table.Column<int>(type: "int", nullable: true),
                    TelefonoFijo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TelefonoMovil = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Torre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Observaciones = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true),
                    IdCondicionIva = table.Column<long>(type: "bigint", nullable: false),
                    RazonSocial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    cod_cliente = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_CondicionIva",
                        column: x => x.IdCondicionIva,
                        principalTable: "CondicionIva",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActualizacionPrecio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdMarca = table.Column<long>(type: "bigint", nullable: true),
                    PorcentajeImporte = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    PrecioLista = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    talledesde = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    tallehasta = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActualizacionPrecio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActualizacionPrecios_Marca",
                        column: x => x.IdMarca,
                        principalTable: "Marca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Legajo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    IdSucursal = table.Column<long>(type: "bigint", nullable: true),
                    Usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedor_Rol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vendedor_Sucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMarca = table.Column<long>(type: "bigint", nullable: false),
                    IdTalle = table.Column<long>(type: "bigint", nullable: false),
                    IdColor = table.Column<long>(type: "bigint", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CodigoBarras = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "money", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PrecioSinIva = table.Column<decimal>(type: "money", nullable: false),
                    Costo = table.Column<decimal>(type: "money", nullable: false),
                    IdImpuesto = table.Column<long>(type: "bigint", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Carrito = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Color",
                        column: x => x.IdColor,
                        principalTable: "Color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Producto_Marca",
                        column: x => x.IdMarca,
                        principalTable: "Marca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Producto_Talle",
                        column: x => x.IdTalle,
                        principalTable: "Talle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoMovimiento = table.Column<long>(type: "bigint", nullable: false),
                    IdSucursalIngreso = table.Column<long>(type: "bigint", nullable: true),
                    IdSucursalEgreso = table.Column<long>(type: "bigint", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Numero = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto_TipoMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_TipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalTable: "TipoMovimiento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Credito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuotas = table.Column<int>(type: "int", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdEstadoCredito = table.Column<long>(type: "bigint", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credito_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Credito_EstadoCredito",
                        column: x => x.IdEstadoCredito,
                        principalTable: "EstadoCredito",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CajaMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCaja = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTipoMovimientoCaja = table.Column<int>(type: "int", nullable: false),
                    IdVendedor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CajaMovimiento_Caja",
                        column: x => x.IdCaja,
                        principalTable: "Caja",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CajaMovimiento_TipoMovimientoCaja",
                        column: x => x.IdTipoMovimientoCaja,
                        principalTable: "TipoMovimientoCaja",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CajaMovimiento_Vendedor",
                        column: x => x.IdVendedor,
                        principalTable: "Vendedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductoImagen",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    LinkImagen = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoImagen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoImagen_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductoStock",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<long>(type: "bigint", nullable: false),
                    IdSucursal = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoStock_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoStock_Sucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comprobante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Letra = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    CentroEmisor = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    IdTipoComprobante = table.Column<long>(type: "bigint", nullable: false),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    RazonSocial = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Cuit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ImporteNeto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Recargos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iva_Tasa1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iva_Tasa2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percepcion_IIBB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCaja = table.Column<int>(type: "int", nullable: true),
                    IdMovimiento = table.Column<long>(type: "bigint", nullable: true),
                    IdAsiento = table.Column<int>(type: "int", nullable: true),
                    IdComprobanteReferencia = table.Column<int>(type: "int", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NC = table.Column<bool>(type: "bit", nullable: true),
                    Garantia = table.Column<bool>(type: "bit", nullable: true),
                    NumeroCAE = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FechaVencimientoCAE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    IdTarjeta = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comproba__3214EC07094B6776", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comprobante_Caja",
                        column: x => x.IdCaja,
                        principalTable: "Caja",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comprobante_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comprobante_Movimiento",
                        column: x => x.IdMovimiento,
                        principalTable: "Movimiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comprobante_TipoComprobante",
                        column: x => x.IdTipoComprobante,
                        principalTable: "TipoComprobante",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteCompra",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Letra = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    ImporteNeto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuentos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IvaTasa_1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IvaTasa_2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percepcion_IIBB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTipoComprobante = table.Column<long>(type: "bigint", nullable: false),
                    IdMovimiento = table.Column<long>(type: "bigint", nullable: false),
                    IdProveedor = table.Column<long>(type: "bigint", nullable: false),
                    IdCaja = table.Column<long>(type: "bigint", nullable: true),
                    PuntoVenta = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtrosImpuestos = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobanteCompra_Proveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComprobanteCompra_TipoComprobante",
                        column: x => x.IdTipoComprobante,
                        principalTable: "TipoComprobante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FacturaCompra_Movimiento",
                        column: x => x.IdMovimiento,
                        principalTable: "Movimiento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductoMovimiento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    IdMovimiento = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoMovimiento_Movimiento",
                        column: x => x.IdMovimiento,
                        principalTable: "Movimiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductoMovimiento_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CuotaCredito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCredito = table.Column<long>(type: "bigint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Amortizacion = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    TotalCuota = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    TotalPago = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaPago = table.Column<DateOnly>(type: "date", nullable: true),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    InteresMora = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotaCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuotaCredito_Credito",
                        column: x => x.IdCredito,
                        principalTable: "Credito",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdEstadoCarrito = table.Column<long>(type: "bigint", nullable: true),
                    IdComprobante = table.Column<int>(type: "int", nullable: true),
                    IdCliente = table.Column<long>(type: "bigint", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrito_Cliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carrito_Comprobante",
                        column: x => x.IdComprobante,
                        principalTable: "Comprobante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Carrito_EstadoCarrito",
                        column: x => x.IdEstadoCarrito,
                        principalTable: "EstadoCarrito",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClienteCuentaCorrienteMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClienteCuentaCorriente = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdComprobante = table.Column<int>(type: "int", nullable: true),
                    Concepto = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Debe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Haber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Vencimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClienteC__3214EC07ADAAEA3C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteCuentaCorrienteMovimiento_ClienteCuentaCorriente",
                        column: x => x.IdClienteCuentaCorriente,
                        principalTable: "ClienteCuentaCorriente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClienteCuentaCorrienteMovimiento_Comprobante",
                        column: x => x.IdComprobante,
                        principalTable: "Comprobante",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    IdComprobante = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImpuestoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonificacion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NC = table.Column<bool>(type: "bit", nullable: true),
                    IdComprobanteItemNC = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobanteItem_Comprobante",
                        column: x => x.IdComprobante,
                        principalTable: "Comprobante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComprobanteItem_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteCompraDescuento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    IdComprobanteCompra = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaCompraDescuento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturaCompraDescuento_FacturaCompra",
                        column: x => x.IdComprobanteCompra,
                        principalTable: "ComprobanteCompra",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteCompraItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    IdComprobanteCompra = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImpuestoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalItem = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteCompraItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobanteCompraItem_ComprobanteCompra",
                        column: x => x.IdComprobanteCompra,
                        principalTable: "ComprobanteCompra",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarritoProducto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarrito = table.Column<long>(type: "bigint", nullable: false),
                    IdProducto = table.Column<long>(type: "bigint", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Carrito",
                        column: x => x.IdCarrito,
                        principalTable: "Carrito",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdFormaPago = table.Column<int>(type: "int", nullable: false),
                    IdClienteCuentaCorrienteMovimiento = table.Column<int>(type: "int", nullable: false),
                    ImportePago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTarjeta = table.Column<int>(type: "int", nullable: true),
                    NumeroTarjeta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NumeroCupon = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NumeroCheque = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FechaCobroCheque = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdCaja = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Caja",
                        column: x => x.IdCaja,
                        principalTable: "Caja",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pago_ClienteCuentaCorrienteMovimiento",
                        column: x => x.IdClienteCuentaCorrienteMovimiento,
                        principalTable: "ClienteCuentaCorrienteMovimiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pago_FormaPago",
                        column: x => x.IdFormaPago,
                        principalTable: "FormaPago",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pago_TarjetaCredito",
                        column: x => x.IdTarjeta,
                        principalTable: "Tarjetum",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActualizacionPrecio_IdMarca",
                table: "ActualizacionPrecio",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_CajaMovimiento_IdCaja",
                table: "CajaMovimiento",
                column: "IdCaja");

            migrationBuilder.CreateIndex(
                name: "IX_CajaMovimiento_IdTipoMovimientoCaja",
                table: "CajaMovimiento",
                column: "IdTipoMovimientoCaja");

            migrationBuilder.CreateIndex(
                name: "IX_CajaMovimiento_IdVendedor",
                table: "CajaMovimiento",
                column: "IdVendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdCliente",
                table: "Carrito",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdComprobante",
                table: "Carrito",
                column: "IdComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_IdEstadoCarrito",
                table: "Carrito",
                column: "IdEstadoCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_IdCarrito",
                table: "CarritoProducto",
                column: "IdCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_IdProducto",
                table: "CarritoProducto",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Cheque_IdBanco",
                table: "Cheque",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCondicionIva",
                table: "Cliente",
                column: "IdCondicionIva");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCuentaCorrienteMovimiento_IdClienteCuentaCorriente",
                table: "ClienteCuentaCorrienteMovimiento",
                column: "IdClienteCuentaCorriente");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCuentaCorrienteMovimiento_IdComprobante",
                table: "ClienteCuentaCorrienteMovimiento",
                column: "IdComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_IdCaja",
                table: "Comprobante",
                column: "IdCaja");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_IdCliente",
                table: "Comprobante",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_IdMovimiento",
                table: "Comprobante",
                column: "IdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_IdTipoComprobante",
                table: "Comprobante",
                column: "IdTipoComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteCompra_IdMovimiento",
                table: "ComprobanteCompra",
                column: "IdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteCompra_IdProveedor",
                table: "ComprobanteCompra",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteCompra_IdTipoComprobante",
                table: "ComprobanteCompra",
                column: "IdTipoComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteCompraDescuento_IdComprobanteCompra",
                table: "ComprobanteCompraDescuento",
                column: "IdComprobanteCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteCompraItem_IdComprobanteCompra",
                table: "ComprobanteCompraItem",
                column: "IdComprobanteCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteItem_IdComprobante",
                table: "ComprobanteItem",
                column: "IdComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteItem_IdProducto",
                table: "ComprobanteItem",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Credito_IdCliente",
                table: "Credito",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Credito_IdEstadoCredito",
                table: "Credito",
                column: "IdEstadoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_CuotaCredito_IdCredito",
                table: "CuotaCredito",
                column: "IdCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Movimiento_IdTipoMovimiento",
                table: "Movimiento",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdCaja",
                table: "Pago",
                column: "IdCaja");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdClienteCuentaCorrienteMovimiento",
                table: "Pago",
                column: "IdClienteCuentaCorrienteMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdFormaPago",
                table: "Pago",
                column: "IdFormaPago");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_IdTarjeta",
                table: "Pago",
                column: "IdTarjeta");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdColor",
                table: "Producto",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdMarca",
                table: "Producto",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdTalle",
                table: "Producto",
                column: "IdTalle");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoImagen_IdProducto",
                table: "ProductoImagen",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMovimiento_IdMovimiento",
                table: "ProductoMovimiento",
                column: "IdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMovimiento_IdProducto",
                table: "ProductoMovimiento",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoStock_IdProducto",
                table: "ProductoStock",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoStock_IdSucursal",
                table: "ProductoStock",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetum_IdBanco",
                table: "Tarjetum",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_IdRol",
                table: "Vendedor",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_IdSucursal",
                table: "Vendedor",
                column: "IdSucursal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActualizacionPrecio");

            migrationBuilder.DropTable(
                name: "CajaMovimiento");

            migrationBuilder.DropTable(
                name: "CarritoProducto");

            migrationBuilder.DropTable(
                name: "Cheque");

            migrationBuilder.DropTable(
                name: "ComprobanteCompraDescuento");

            migrationBuilder.DropTable(
                name: "ComprobanteCompraItem");

            migrationBuilder.DropTable(
                name: "ComprobanteItem");

            migrationBuilder.DropTable(
                name: "CuotaCredito");

            migrationBuilder.DropTable(
                name: "Deposito");

            migrationBuilder.DropTable(
                name: "Impuesto");

            migrationBuilder.DropTable(
                name: "Iva");

            migrationBuilder.DropTable(
                name: "NHibernateTest");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "PreciosTable");

            migrationBuilder.DropTable(
                name: "Producto2");

            migrationBuilder.DropTable(
                name: "ProductoImagen");

            migrationBuilder.DropTable(
                name: "ProductoMovimiento");

            migrationBuilder.DropTable(
                name: "ProductoStock");

            migrationBuilder.DropTable(
                name: "ProveedorCuentaCorriente");

            migrationBuilder.DropTable(
                name: "ProveedorCuentaCorrienteMovimiento");

            migrationBuilder.DropTable(
                name: "TalleCentral");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoMovimientoCaja");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "ComprobanteCompra");

            migrationBuilder.DropTable(
                name: "Credito");

            migrationBuilder.DropTable(
                name: "ClienteCuentaCorrienteMovimiento");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "Tarjetum");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "EstadoCarrito");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "EstadoCredito");

            migrationBuilder.DropTable(
                name: "ClienteCuentaCorriente");

            migrationBuilder.DropTable(
                name: "Comprobante");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Talle");

            migrationBuilder.DropTable(
                name: "Caja");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Movimiento");

            migrationBuilder.DropTable(
                name: "TipoComprobante");

            migrationBuilder.DropTable(
                name: "CondicionIva");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");
        }
    }
}
