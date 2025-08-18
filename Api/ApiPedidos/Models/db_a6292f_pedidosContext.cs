using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiPedidos.Models
{
    public partial class db_a6292f_pedidosContext : DbContext
    {
        public db_a6292f_pedidosContext()
        {
        }

        public db_a6292f_pedidosContext(DbContextOptions<db_a6292f_pedidosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banco> Bancos { get; set; } = null!;
        public virtual DbSet<Cai> Cais { get; set; } = null!;
        public virtual DbSet<Caja> Cajas { get; set; } = null!;
        public virtual DbSet<CajaMovimiento> CajaMovimientos { get; set; } = null!;
        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<CarritoItem> CarritoItems { get; set; } = null!;
        public virtual DbSet<Cheque> Cheques { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cliente1> Clientes1 { get; set; } = null!;
        public virtual DbSet<ClienteBonificacion> ClienteBonificacions { get; set; } = null!;
        public virtual DbSet<ClienteCuentaCorriente> ClienteCuentaCorrientes { get; set; } = null!;
        public virtual DbSet<ClienteCuentaCorrienteMovimiento> ClienteCuentaCorrienteMovimientos { get; set; } = null!;
        public virtual DbSet<Comprobante> Comprobantes { get; set; } = null!;
        public virtual DbSet<ComprobanteCompra> ComprobanteCompras { get; set; } = null!;
        public virtual DbSet<ComprobanteCompraDescuento> ComprobanteCompraDescuentos { get; set; } = null!;
        public virtual DbSet<ComprobanteCompraItem> ComprobanteCompraItems { get; set; } = null!;
        public virtual DbSet<ComprobanteItem> ComprobanteItems { get; set; } = null!;
        public virtual DbSet<CondicionIva> CondicionIvas { get; set; } = null!;
        public virtual DbSet<Deposito> Depositos { get; set; } = null!;
        public virtual DbSet<DetRemito> DetRemitos { get; set; } = null!;
        public virtual DbSet<Ejercicio> Ejercicios { get; set; } = null!;
        public virtual DbSet<FormaPago> FormaPagos { get; set; } = null!;
        public virtual DbSet<Impuesto> Impuestos { get; set; } = null!;
        public virtual DbSet<Iva> Ivas { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Marca2> Marca2s { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<NhibernateTest> NhibernateTests { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Parametro> Parametros { get; set; } = null!;
        public virtual DbSet<Precio> Precios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<ProductoMovimiento> ProductoMovimientos { get; set; } = null!;
        public virtual DbSet<ProductoStock> ProductoStocks { get; set; } = null!;
        public virtual DbSet<Productosnuevo> Productosnuevos { get; set; } = null!;
        public virtual DbSet<Proveedor> Proveedors { get; set; } = null!;
        public virtual DbSet<ProveedorCuentaCorriente> ProveedorCuentaCorrientes { get; set; } = null!;
        public virtual DbSet<ProveedorCuentaCorrienteMovimiento> ProveedorCuentaCorrienteMovimientos { get; set; } = null!;
        public virtual DbSet<Remito> Remitos { get; set; } = null!;
        public virtual DbSet<Rubro> Rubros { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursals { get; set; } = null!;
        public virtual DbSet<Talle> Talles { get; set; } = null!;
        public virtual DbSet<Tarjetum> Tarjeta { get; set; } = null!;
        public virtual DbSet<TipoCliente> TipoClientes { get; set; } = null!;
        public virtual DbSet<TipoComprobante> TipoComprobantes { get; set; } = null!;
        public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; } = null!;
        public virtual DbSet<TipoMovimientoCaja> TipoMovimientoCajas { get; set; } = null!;
        public virtual DbSet<TipoPrecio> TipoPrecios { get; set; } = null!;
        public virtual DbSet<TipoRubro> TipoRubros { get; set; } = null!;
        public virtual DbSet<Vendedor> Vendedors { get; set; } = null!;
        public virtual DbSet<Veterinarium> Veterinaria { get; set; } = null!;
        public virtual DbSet<Voto> Votos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQL5098.site4now.net;DataBase =db_a6292f_pedidos;User Id=db_a6292f_pedidos_admin;Password=mapi1986.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.ToTable("Banco");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cai>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CAI");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
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

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.CajaMovimientos)
                    .HasForeignKey(d => d.IdCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CajaMovimiento_Caja");

                entity.HasOne(d => d.IdTipoMovimientoCajaNavigation)
                    .WithMany(p => p.CajaMovimientos)
                    .HasForeignKey(d => d.IdTipoMovimientoCaja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CajaMovimiento_TipoMovimientoCaja");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.CajaMovimientos)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_CajaMovimiento_Vendedor");
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Cliente");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Vendedor");
            });

            modelBuilder.Entity<CarritoItem>(entity =>
            {
                entity.ToTable("CarritoItem");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Punitario)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PUnitario");

                entity.HasOne(d => d.oCarrito)
                    .WithMany(p => p.CarritoItems)
                    .HasForeignKey(d => d.IdCarrito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarritoItem_Carrito");

                entity.HasOne(d => d.oProducto)
                    .WithMany(p => p.CarritoItems)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarritoItem_Producto");
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

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.Cheques)
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
                    .HasColumnName("cod_cliente")
                    .IsFixedLength();

                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Depto)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1000)
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

                entity.HasOne(d => d.oCondicionIva)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdCondicionIva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_CondicionIva");

                entity.HasOne(d => d.oTipoCliente)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoCliente)
                    .HasConstraintName("FK_Cliente_TipoCliente");
            });

            modelBuilder.Entity<Cliente1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("clientes");

                entity.Property(e => e.ApeNom)
                    .HasMaxLength(255)
                    .HasColumnName("Ape_Nom");

                entity.Property(e => e.Calle).HasMaxLength(255);

                entity.Property(e => e.CodCliente).HasColumnName("Cod_Cliente");

                entity.Property(e => e.CodigoPostal).HasMaxLength(255);

                entity.Property(e => e.ConIva).HasColumnName("Con_IVA");

                entity.Property(e => e.Cuit)
                    .HasMaxLength(255)
                    .HasColumnName("CUIT");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Fax).HasMaxLength(255);

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaALta");

                entity.Property(e => e.Localidad).HasMaxLength(255);

                entity.Property(e => e.Nro).HasMaxLength(255);

                entity.Property(e => e.Observacion).HasMaxLength(255);

                entity.Property(e => e.PisoDpto)
                    .HasMaxLength(255)
                    .HasColumnName("Piso_Dpto");

                entity.Property(e => e.Provincia).HasMaxLength(255);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(255)
                    .HasColumnName("Razon_Social");

                entity.Property(e => e.Telefono).HasMaxLength(255);
            });

            modelBuilder.Entity<ClienteBonificacion>(entity =>
            {
                entity.ToTable("ClienteBonificacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descuento).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.ClienteBonificacions)
                    .HasForeignKey(d => d.IdRubro)
                    .HasConstraintName("FK_ClienteBonificacion_Rubro");

                entity.HasOne(d => d.IdTipoClienteNavigation)
                    .WithMany(p => p.ClienteBonificacions)
                    .HasForeignKey(d => d.IdTipoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteBonificacion_TipoCliente");
            });

            modelBuilder.Entity<ClienteCuentaCorriente>(entity =>
            {
                entity.ToTable("ClienteCuentaCorriente");

                entity.Property(e => e.Saldo).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClienteCuentaCorrientes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteCuentaCorriente_ClienteCuentaCorriente");
            });

            modelBuilder.Entity<ClienteCuentaCorrienteMovimiento>(entity =>
            {
                entity.ToTable("ClienteCuentaCorrienteMovimiento");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Debe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Haber).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Vencimiento).HasColumnType("datetime");

                entity.HasOne(d => d.IdClienteCuentaCorrienteNavigation)
                    .WithMany(p => p.ClienteCuentaCorrienteMovimientos)
                    .HasForeignKey(d => d.IdClienteCuentaCorriente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClienteCuentaCorrienteMovimiento_ClienteCuentaCorriente");

                entity.HasOne(d => d.IdComprobanteNavigation)
                    .WithMany(p => p.ClienteCuentaCorrienteMovimientos)
                    .HasForeignKey(d => d.IdComprobante)
                    .HasConstraintName("FK_ClienteCuentaCorrienteMovimiento_Comprobante");
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.ToTable("Comprobante");

                entity.Property(e => e.Cai).HasColumnName("CAI");

                entity.Property(e => e.CentroEmisor)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimientoCae)
                    .HasMaxLength(10)
                    .HasColumnName("FechaVencimientoCAE")
                    .IsFixedLength();

                entity.Property(e => e.Idanterior).HasColumnName("idanterior");

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

                entity.Property(e => e.NumeroCae)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NumeroCAE");

                entity.Property(e => e.ObservacionesAfip)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ObservacionesAFIP");

                entity.Property(e => e.PercepcionIibb)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Percepcion_IIBB");

                entity.Property(e => e.PuntoVenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Recargos).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDolares).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_Comprobante_Caja");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comprobante_Cliente");

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdMovimiento)
                    .HasConstraintName("FK_Comprobante_Movimiento");

                entity.HasOne(d => d.IdTipoComprobanteNavigation)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(d => d.IdTipoComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comprobante_TipoComprobante");
            });

            modelBuilder.Entity<ComprobanteCompra>(entity =>
            {
                entity.ToTable("ComprobanteCompra");

                entity.Property(e => e.Descuentos).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.ImporteNeto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IvaTasa).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IvaTasax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Letra)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Numero)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PercepcionIibb)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Percepcion_IIBB");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.ComprobanteCompras)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_ComprobanteCompra_Caja");

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.ComprobanteCompras)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaCompra_Movimiento");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.ComprobanteCompras)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaCompra_Proveedor");

                entity.HasOne(d => d.IdTipoComprobanteNavigation)
                    .WithMany(p => p.ComprobanteCompras)
                    .HasForeignKey(d => d.IdTipoComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteCompra_TipoComprobante");
            });

            modelBuilder.Entity<ComprobanteCompraDescuento>(entity =>
            {
                entity.ToTable("ComprobanteCompraDescuento");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Porcentaje).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.IdComprobanteCompraNavigation)
                    .WithMany(p => p.ComprobanteCompraDescuentos)
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

                entity.HasOne(d => d.IdComprobanteCompraNavigation)
                    .WithMany(p => p.ComprobanteCompraItems)
                    .HasForeignKey(d => d.IdComprobanteCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteCompraItem_ComprobanteCompra");
            });

            modelBuilder.Entity<ComprobanteItem>(entity =>
            {
                entity.ToTable("ComprobanteItem");

                entity.Property(e => e.Bonificacion).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(10, 3)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRemito).HasColumnType("datetime");

                entity.Property(e => e.ImpuestoUnitario).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalItem).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdComprobanteNavigation)
                    .WithMany(p => p.ComprobanteItems)
                    .HasForeignKey(d => d.IdComprobante)
                    .HasConstraintName("FK_ComprobanteItem_Comprobante");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ComprobanteItems)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteItem_Producto");
            });

            modelBuilder.Entity<CondicionIva>(entity =>
            {
                entity.ToTable("CondicionIva");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.ToTable("Deposito");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetRemito>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("det_remitos");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(255)
                    .HasColumnName("codigo");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(255)
                    .HasColumnName("detalle");

                entity.Property(e => e.ImporteTotal).HasColumnName("importe_total");

                entity.Property(e => e.ImporteUnitario).HasColumnName("importe_unitario");

                entity.Property(e => e.Iva).HasColumnName("iva");

                entity.Property(e => e.NroRemito)
                    .HasMaxLength(255)
                    .HasColumnName("nro_remito");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.ToTable("Ejercicio");

                entity.Property(e => e.CierreParcial).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCierre).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");
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

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca2>(entity =>
            {
                entity.ToTable("Marca2");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("Movimiento");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Movimiento_Cliente");

                entity.HasOne(d => d.IdSucursalEgresoNavigation)
                    .WithMany(p => p.MovimientoIdSucursalEgresoNavigations)
                    .HasForeignKey(d => d.IdSucursalEgreso)
                    .HasConstraintName("FK_Movimiento_SucursalEgreso");

                entity.HasOne(d => d.IdSucursalIngresoNavigation)
                    .WithMany(p => p.MovimientoIdSucursalIngresoNavigations)
                    .HasForeignKey(d => d.IdSucursalIngreso)
                    .HasConstraintName("FK_Movimiento_SucursalIngreso");

                entity.HasOne(d => d.IdTipoMovimientoNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdTipoMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimiento_TipoMovimiento");
            });

            modelBuilder.Entity<NhibernateTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("NHibernateTest");

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

                entity.HasOne(d => d.IdCajaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdCaja)
                    .HasConstraintName("FK_Pago_Caja");

                entity.HasOne(d => d.IdClienteCuentaCorrienteMovimientoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdClienteCuentaCorrienteMovimiento)
                    .HasConstraintName("FK_Pago_ClienteCuentaCorrienteMovimiento");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pago_FormaPago");

                entity.HasOne(d => d.IdTarjetaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdTarjeta)
                    .HasConstraintName("FK_Pago_TarjetaCredito");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.ToTable("Parametro");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("ntext");
            });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("precios");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Precio1).HasColumnName("Precio");
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

                entity.Property(e => e.FechaActualizacion).HasColumnType("date");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LoteMinimoCompra).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.Property(e => e.PrecioSinIva).HasColumnType("money");

                entity.Property(e => e.PuntoPedido).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Remarca).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.StockMaximo).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.oMarca)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Marca");

                entity.HasOne(d => d.oRubro)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdRubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Rubro");
            });

            modelBuilder.Entity<ProductoMovimiento>(entity =>
            {
                entity.ToTable("ProductoMovimiento");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.ProductoMovimientos)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoMovimiento_Movimiento");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductoMovimientos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoMovimiento_Producto");
            });

            modelBuilder.Entity<ProductoStock>(entity =>
            {
                entity.ToTable("ProductoStock");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.ProductoStocks)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoStock_Producto");

                entity.HasOne(d => d.IdSucursalNavigation)
                    .WithMany(p => p.ProductoStocks)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoStock_Sucursal");
            });

            modelBuilder.Entity<Productosnuevo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productosnuevos");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Marca)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("marca");
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
                entity.ToTable("ProveedorCuentaCorriente");

                entity.Property(e => e.Saldo).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<ProveedorCuentaCorrienteMovimiento>(entity =>
            {
                entity.ToTable("ProveedorCuentaCorrienteMovimiento");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Debe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Haber).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Vencimiento).HasColumnType("datetime");
            });

            modelBuilder.Entity<Remito>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("remitos");

                entity.Property(e => e.CodCliente).HasColumnName("cod_cliente");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.ImporteTotal).HasColumnName("importe_total");

                entity.Property(e => e.NroFact)
                    .HasMaxLength(255)
                    .HasColumnName("nroFact");

                entity.Property(e => e.NroRemito)
                    .HasMaxLength(255)
                    .HasColumnName("nro_remito");

                entity.Property(e => e.Retirado)
                    .HasMaxLength(255)
                    .HasColumnName("retirado");

                entity.Property(e => e.TipoFact)
                    .HasMaxLength(255)
                    .HasColumnName("tipoFact");

                entity.Property(e => e.TipoRemito)
                    .HasMaxLength(255)
                    .HasColumnName("tipoRemito");
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.ToTable("Rubro");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.ToTable("Sucursal");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cuit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUIT");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InicioActividad).HasColumnType("datetime");

                entity.Property(e => e.TipoResponsabilidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UltimoNumeroCai)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UltimoNumeroCAI");
            });

            modelBuilder.Entity<Talle>(entity =>
            {
                entity.ToTable("Talle");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tarjetum>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarjetaCredito_Banco");
            });

            modelBuilder.Entity<TipoCliente>(entity =>
            {
                entity.ToTable("TipoCliente");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoComprobante>(entity =>
            {
                entity.ToTable("TipoComprobante");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Letra)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoMovimiento>(entity =>
            {
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

            modelBuilder.Entity<TipoPrecio>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tipoPrecios");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodTipo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Cod_Tipo");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(255)
                    .HasColumnName("codigo");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(255)
                    .HasColumnName("detalle");

                entity.Property(e => e.Ganancia).HasColumnName("ganancia");

                entity.Property(e => e.Importe).HasColumnName("importe");

                entity.Property(e => e.ImporteSinIva).HasColumnName("importeSinIva");

                entity.Property(e => e.Iva).HasColumnName("IVA");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.StockMinimo).HasColumnName("stockMinimo");

                entity.Property(e => e.Tasa)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tasa");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(255)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<TipoRubro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tipoRubros");

                entity.Property(e => e.Detalle).HasMaxLength(255);

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.ToTable("Vendedor");

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

                entity.Property(e => e.Legajo)
                    .HasMaxLength(10)
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

            modelBuilder.Entity<Veterinarium>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("veterinaria");

                entity.Property(e => e.CEfectivo).HasColumnName("C# Efectivo");

                entity.Property(e => e.Características).HasMaxLength(255);

                entity.Property(e => e.CostoUnid).HasColumnName("Costo/unid");

                entity.Property(e => e.Marca).HasMaxLength(255);

                entity.Property(e => e.MargenFraccionado).HasColumnName("Margen Fraccionado");

                entity.Property(e => e.PCompra).HasColumnName("P# compra");

                entity.Property(e => e.PFracEfec).HasColumnName("P# Frac# Efec#");

                entity.Property(e => e.PLista).HasColumnName("P# Lista");

                entity.Property(e => e.PListaFrac).HasColumnName("P# Lista Frac#");

                entity.Property(e => e.PesoKg).HasColumnName("Peso (Kg#)");

                entity.Property(e => e.Producto).HasMaxLength(255);

                entity.Property(e => e.Proveedor).HasMaxLength(255);

                entity.Property(e => e.Rubro).HasMaxLength(255);

                entity.Property(e => e.Sección).HasMaxLength(255);

                entity.Property(e => e.Unidad).HasMaxLength(255);

                entity.Property(e => e.Unidad2).HasMaxLength(255);

                entity.Property(e => e.UtilidadFracc).HasColumnName("Utilidad Fracc#");
            });

            modelBuilder.Entity<Voto>(entity =>
            {
                entity.ToTable("VOTOS");

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTO");

                entity.Property(e => e.Opcion).HasColumnName("OPCION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
