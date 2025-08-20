using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApiCarrito.Models;

namespace WebApiCarrito.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString,
                sqlServerOptionsAction: config =>
                {
                    config.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).FullName);
                });
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<ActualizacionPrecio>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PorcentajeImporte).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PrecioLista)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Talledesde)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("talledesde");
                entity.Property(e => e.Tallehasta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tallehasta");

                entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.ActualizacionPrecios)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_ActualizacionPrecios_Marca");
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.ToTable("Banco");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Caja>(entity =>
            {
                entity.ToTable("Caja");

                entity.Property(e => e.FechaApertura).HasColumnType("datetime");
                entity.Property(e => e.FechaCierre).HasColumnType("datetime");
            });

            modelBuilder.Entity<CajaMovimiento>(entity =>
            {
                entity.ToTable("CajaMovimiento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCajaNavigation).WithMany(p => p.CajaMovimientos)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CajaMovimiento_Caja");

                entity.HasOne(d => d.IdTipoMovimientoCajaNavigation).WithMany(p => p.CajaMovimientos)
                    .HasForeignKey(d => d.IdTipoMovimientoCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CajaMovimiento_TipoMovimientoCaja");

                entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.CajaMovimientos)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CajaMovimiento_Vendedor");
            });

            modelBuilder.Entity<Cheque>(entity =>
            {
                entity.ToTable("Cheque");

                entity.Property(e => e.FechaCobro).HasColumnType("datetime");
                entity.Property(e => e.FechaEmision).HasColumnType("datetime");
                entity.Property(e => e.ImporteCheque).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Sucursal)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBancoNavigation).WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.IdBanco)
                    .HasConstraintName("FK_Cheque_Banco");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Calle)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CodCliente)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("cod_cliente");
                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Depto)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Observaciones)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.TelefonoFijo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TelefonoMovil)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Torre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCondicionIvaNavigation).WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdCondicionIva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_CondicionIva");
            });

            modelBuilder.Entity<ClienteCuentaCorriente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__ClienteC__3214EC07D106135B");

                entity.ToTable("ClienteCuentaCorriente");

                entity.Property(e => e.Saldo).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<ClienteCuentaCorrienteMovimiento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__ClienteC__3214EC074288A80D");

                entity.ToTable("ClienteCuentaCorrienteMovimiento");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Debe).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.Haber).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Vencimiento).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteCuentaCorrienteNavigation).WithMany(p => p.ClienteCuentaCorrienteMovimientos)
                    .HasForeignKey(d => d.IdClienteCuentaCorriente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteCuentaCorrienteMovimiento_ClienteCuentaCorriente");

                entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.ClienteCuentaCorrienteMovimientos)
                    .HasForeignKey(d => d.IdComprobante)
                    .HasConstraintName("FK_ClienteCuentaCorrienteMovimiento_Comprobante");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Comproba__3214EC07094B6776");

                entity.ToTable("Comprobante");

                entity.Property(e => e.CentroEmisor)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.FechaVencimientoCae)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FechaVencimientoCAE");
                entity.Property(e => e.ImporteNeto).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.IvaTasa1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Iva_Tasa1");
                entity.Property(e => e.IvaTasa2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Iva_Tasa2");
                entity.Property(e => e.Letra)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Nc).HasColumnName("NC");
                entity.Property(e => e.NumeroCae)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NumeroCAE");
                entity.Property(e => e.PercepcionIibb)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Percepcion_IIBB");
                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Recargos).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCajaNavigation).WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_Comprobante_Caja");

                entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comprobante_Cliente");

                entity.HasOne(d => d.IdMovimientoNavigation).WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdMovimiento)
                    .HasConstraintName("FK_Comprobante_Movimiento");

                entity.HasOne(d => d.IdTipoComprobanteNavigation).WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdTipoComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comprobante_TipoComprobante");
            });

            modelBuilder.Entity<ComprobanteCompra>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FacturaCompra");

                entity.ToTable("ComprobanteCompra");

                entity.Property(e => e.Descuentos).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ImporteNeto).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.IvaTasa1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IvaTasa_1");
                entity.Property(e => e.IvaTasa2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IvaTasa_2");
                entity.Property(e => e.Letra)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.OtrosImpuestos).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PercepcionIibb)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Percepcion_IIBB");
                entity.Property(e => e.PuntoVenta)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdMovimientoNavigation).WithMany(p => p.ComprobanteCompras)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaCompra_Movimiento");

                entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.ComprobanteCompras)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteCompra_Proveedor");

                entity.HasOne(d => d.IdTipoComprobanteNavigation).WithMany(p => p.ComprobanteCompras)
                    .HasForeignKey(d => d.IdTipoComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteCompra_TipoComprobante");
            });

            modelBuilder.Entity<ComprobanteCompraDescuento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FacturaCompraDescuento");

                entity.ToTable("ComprobanteCompraDescuento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Porcentaje).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.IdComprobanteCompraNavigation).WithMany(p => p.ComprobanteCompraDescuentos)
                    .HasForeignKey(d => d.IdComprobanteCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaCompraDescuento_FacturaCompra");
            });

            modelBuilder.Entity<ComprobanteCompraItem>(entity =>
            {
                entity.ToTable("ComprobanteCompraItem");

                entity.Property(e => e.ImpuestoUnitario).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TotalItem).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdComprobanteCompraNavigation).WithMany(p => p.ComprobanteCompraItems)
                    .HasForeignKey(d => d.IdComprobanteCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteCompraItem_ComprobanteCompra");
            });

            modelBuilder.Entity<ComprobanteItem>(entity =>
            {
                entity.ToTable("ComprobanteItem");

                entity.Property(e => e.Bonificacion).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.IdComprobanteItemNc).HasColumnName("IdComprobanteItemNC");
                entity.Property(e => e.ImpuestoUnitario).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Nc).HasColumnName("NC");
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TotalItem).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdComprobanteNavigation).WithMany(p => p.ComprobanteItems)
                    .HasForeignKey(d => d.IdComprobante)
                    .HasConstraintName("FK_ComprobanteItem_Comprobante");

                entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ComprobanteItems)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteItem_Producto");
            });

            modelBuilder.Entity<CondicionIva>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Condicio__3214EC074CD2F307");

                entity.ToTable("CondicionIva");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.ToTable("Credito");

                entity.Property(e => e.Capital).HasColumnType("decimal(16, 2)");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Interes).HasColumnType("decimal(16, 2)");
                entity.Property(e => e.Saldo).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credito_Cliente");

                entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credito_EstadoCredito");
            });

            modelBuilder.Entity<CuotaCredito>(entity =>
            {
                entity.ToTable("CuotaCredito");

                entity.Property(e => e.Amortizacion).HasColumnType("decimal(16, 2)");
                entity.Property(e => e.Interes).HasColumnType("decimal(16, 2)");
                entity.Property(e => e.InteresMora).HasColumnType("decimal(16, 2)");
                entity.Property(e => e.TotalCuota).HasColumnType("decimal(16, 2)");
                entity.Property(e => e.TotalPago).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdCreditoNavigation).WithMany(p => p.CuotaCreditos)
                    .HasForeignKey(d => d.IdCredito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuotaCredito_Credito");
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.ToTable("Deposito");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoCredito>(entity =>
            {
                entity.ToTable("EstadoCredito");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.ToTable("FormaPago");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Impuesto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Impuesto__3214EC0726ECC11F");

                entity.ToTable("Impuesto");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Alicuota).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Iva>(entity =>
            {
                entity.ToTable("Iva");

                entity.Property(e => e.Descripcion).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marca");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Producto_TipoMovimiento");

                entity.ToTable("Movimiento");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdTipoMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimiento_TipoMovimiento");
            });

            modelBuilder.Entity<NhibernateTest>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("NHibernateTest");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("Pago");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.FechaCobroCheque).HasColumnType("datetime");
                entity.Property(e => e.ImportePago).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.NumeroCheque)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.NumeroCupon)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.NumeroTarjeta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCajaNavigation).WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_Pago_Caja");

                entity.HasOne(d => d.IdClienteCuentaCorrienteMovimientoNavigation).WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdClienteCuentaCorrienteMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_ClienteCuentaCorrienteMovimiento");

                entity.HasOne(d => d.IdFormaPagoNavigation).WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_FormaPago");

                entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdTarjeta)
                    .HasConstraintName("FK_Pago_TarjetaCredito");
            });

            modelBuilder.Entity<PreciosTable>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("PreciosTable");

                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Costo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Precio)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.PrecioSinIva)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.CodigoBarras)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Costo).HasColumnType("money");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Precio).HasColumnType("money");
                entity.Property(e => e.PrecioSinIva).HasColumnType("money");

                entity.HasOne(d => d.IdColorNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Color");

                entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Marca");

                entity.HasOne(d => d.IdTalleNavigation).WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Talle");
            });


            modelBuilder.Entity<ProductoMovimiento>(entity =>
            {
                entity.ToTable("ProductoMovimiento");

                entity.HasOne(d => d.IdMovimientoNavigation).WithMany(p => p.ProductoMovimientos)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoMovimiento_Movimiento");

                entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoMovimientos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoMovimiento_Producto");
            });

            modelBuilder.Entity<ProductoStock>(entity =>
            {
                entity.ToTable("ProductoStock");

                entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoStocks)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoStock_Producto");

                entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.ProductoStocks)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoStock_Sucursal");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Calle)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Depto)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Observaciones)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
                entity.Property(e => e.TelefonoFijo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TelefonoMovil)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Torre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProveedorCuentaCorriente>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC078A156922");

                entity.ToTable("ProveedorCuentaCorriente");

                entity.Property(e => e.Saldo).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<ProveedorCuentaCorrienteMovimiento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC0741C13710");

                entity.ToTable("ProveedorCuentaCorrienteMovimiento");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Debe).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.Haber).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Vencimiento).HasColumnType("datetime");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Sucursal_1");

                entity.ToTable("Sucursal");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Coneccion)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.MailPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PathDownloads)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PathPrecios)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PathRemitos)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Talle>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Modelo");

                entity.ToTable("Talle");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TalleCentral>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Modelo_");

                entity.ToTable("TalleCentral");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tarjetum>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_TarjetaCredito");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ExpirationTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.FechaInicioActividades)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Observaciones)
                    .HasMaxLength(8000)
                    .IsUnicode(false);
                entity.Property(e => e.PassCert)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.PathCertificado)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.PathImagen)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Sign).IsUnicode(false);
                entity.Property(e => e.Token).IsUnicode(false);

                entity.HasOne(d => d.IdBancoNavigation).WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarjetaCredito_Banco");
            });

            modelBuilder.Entity<TipoComprobante>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TipoComp__3214EC07F4B0087B");

                entity.ToTable("TipoComprobante");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Letra)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Movimiento");

                entity.ToTable("TipoMovimiento");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMovimientoCaja>(entity =>
            {
                entity.ToTable("TipoMovimientoCaja");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("Vendedor");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Legajo)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Vendedors)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_Vendedor_Rol");

                entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Vendedors)
                    .HasForeignKey(d => d.IdSucursal)
                    .HasConstraintName("FK_Vendedor_Sucursal");
            });

        }

        public DbSet<WebApiCarrito.Models.Producto> Producto { get; set; } = default!;
        public DbSet<WebApiCarrito.Models.Talle> Talle { get; set; } = default!;
        public DbSet<WebApiCarrito.Models.Color> Color { get; set; } = default!;
        public DbSet<WebApiCarrito.Models.Marca> Marca { get; set; } = default!;
     
    }
}