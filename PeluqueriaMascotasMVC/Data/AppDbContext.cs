using Microsoft.EntityFrameworkCore;
using PeluqueriaMascotasMVC.Models;

namespace PeluqueriaMascotasMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tablas de Usuarios y Personal
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        // Tablas de Mascotas
        public DbSet<Mascota> Mascotas { get; set; }

        // Tablas de Servicios y Turnos
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        // Tablas de Productos y Stock
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<StockItem> StockItems { get; set; }

        // Tablas de Compras y Carrito
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===================== CONFIGURACIÓN DE PERSONA (TPH) =====================
            modelBuilder.Entity<Persona>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Persona>()
                .HasDiscriminator<string>("PersonaType")
                .HasValue<Cliente>("Cliente")
                .HasValue<Empleado>("Empleado");

            modelBuilder.Entity<Persona>()
                .Property(p => p.Usuario)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Persona>()
                .Property(p => p.Contraseña)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Persona>()
                .Property(p => p.Mail)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Persona>()
                .Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Persona>()
                .Property(p => p.Apellido)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Persona>()
                .Property(p => p.Telefono)
                .HasMaxLength(20);

            modelBuilder.Entity<Persona>()
                .Property(p => p.Direccion)
                .HasMaxLength(200);

            // ===================== CONFIGURACIÓN DE CLIENTE =====================
            modelBuilder.Entity<Cliente>()
                .Property(c => c.Dni)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Dni)
                .IsUnique();

            // ===================== CONFIGURACIÓN DE MASCOTA =====================
            modelBuilder.Entity<Mascota>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Mascota>()
                .Property(m => m.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Mascota>()
                .Property(m => m.Tipo)
                .IsRequired();

            modelBuilder.Entity<Mascota>()
                .HasOne(m => m.Cliente)
                .WithMany(c => c.Mascotas)
                .HasForeignKey(m => m.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===================== CONFIGURACIÓN DE SERVICIO =====================
            modelBuilder.Entity<Servicio>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Servicio>()
                .Property(s => s.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Servicio>()
                .Property(s => s.Descripcion)
                .HasMaxLength(500);

            modelBuilder.Entity<Servicio>()
                .Property(s => s.Precio)
                .HasPrecision(10, 2)
                .IsRequired();

            modelBuilder.Entity<Servicio>()
                .Property(s => s.Activo)
                .HasDefaultValue(true);

            // ===================== CONFIGURACIÓN DE TURNO =====================
            modelBuilder.Entity<Turno>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Mascota)
                .WithMany()
                .HasForeignKey(t => t.MascotaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Servicio)
                .WithMany()
                .HasForeignKey(t => t.ServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Turno>()
                .Property(t => t.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");

            modelBuilder.Entity<Turno>()
                .Property(t => t.Notas)
                .HasMaxLength(500);

            // ===================== CONFIGURACIÓN DE CONSULTA =====================
            modelBuilder.Entity<Consulta>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Mascota)
                .WithMany()
                .HasForeignKey(c => c.MascotaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Servicio)
                .WithMany()
                .HasForeignKey(c => c.ServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Consulta>()
                .Property(c => c.Observaciones)
                .HasMaxLength(500);

            modelBuilder.Entity<Consulta>()
                .Property(c => c.Diagnostico)
                .HasMaxLength(500);

            modelBuilder.Entity<Consulta>()
                .Property(c => c.Tratamiento)
                .HasMaxLength(500);

            // ===================== CONFIGURACIÓN DE PRODUCTO =====================
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Producto>()
                .Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .Property(p => p.Descripcion)
                .HasMaxLength(500);

            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(10, 2)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            // ===================== CONFIGURACIÓN DE CATEGORIA =====================
            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Descripcion)
                .HasMaxLength(500);

            // ===================== CONFIGURACIÓN DE STOCKITEM =====================
            modelBuilder.Entity<StockItem>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<StockItem>()
                .HasOne(s => s.Producto)
                .WithMany()
                .HasForeignKey(s => s.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===================== CONFIGURACIÓN DE CARRITO =====================
            modelBuilder.Entity<Carrito>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Carrito>()
                .HasMany(c => c.CarritoItems)
                .WithOne()
                .HasForeignKey(ci => ci.CarritoId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===================== CONFIGURACIÓN DE CARRITOITEM =====================
            modelBuilder.Entity<CarritoItem>()
                .HasKey(ci => ci.Id);

            modelBuilder.Entity<CarritoItem>()
                .HasOne(ci => ci.Producto)
                .WithMany()
                .HasForeignKey(ci => ci.ProductoId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CarritoItem>()
                .HasOne(ci => ci.Servicio)
                .WithMany()
                .HasForeignKey(ci => ci.ServicioId)
                .OnDelete(DeleteBehavior.SetNull);

            // ===================== CONFIGURACIÓN DE COMPRA =====================
            modelBuilder.Entity<Compra>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Compra>()
                .HasMany(c => c.Items)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Compra>()
                .Property(c => c.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");
        }
    }
}
