using GymSystem.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GymSystem.Datos
{
    public class GymDbContext : DbContext
    {
        public GymDbContext()
        {
        }

        public GymDbContext(
            DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();

        public DbSet<Plan> Planes => Set<Plan>();

        public DbSet<Inscripcion> Inscripciones =>
            Set<Inscripcion>();

        public DbSet<Pago> Pagos => Set<Pago>();

        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    Conexion.CadenaConexion);
            }
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CLIENTES
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");

                entity.HasKey(c => c.IdCliente)
                    .HasName("PK__Clientes__D5946642B9512E68");

                entity.Property(c => c.IdCliente)
                    .UseIdentityColumn(1, 1);

                entity.Property(c => c.Nombre)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(c => c.NumeroCedula)
                    .HasColumnType("varchar(20)")
                    .IsRequired();

                entity.Property(c => c.Correo)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(c => c.Telefono)
                    .HasColumnType("varchar(20)");

                entity.Property(c => c.Direccion)
                    .HasColumnType("varchar(200)");

                entity.Property(c => c.FechaNacimiento)
                    .HasColumnType("date");

                entity.Property(c => c.Activo)
                    .HasDefaultValue(true);

                entity.HasIndex(c => c.NumeroCedula)
                    .IsUnique()
                    .HasDatabaseName("UQ_Clientes_Cedula");

                entity.HasIndex(c => c.Correo)
                    .IsUnique()
                    .HasDatabaseName("UQ_Clientes_Correo");
            });

            // PLANES
            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("Planes", table =>
                {
                    table.HasCheckConstraint(
                        "CK_Planes_Duracion",
                        "([DuracionDias]>(0))");

                    table.HasCheckConstraint(
                        "CK_Planes_Precio",
                        "([Precio]>(0))");
                });

                entity.HasKey(p => p.IdPlan)
                    .HasName("PK__Planes__FB8102AE5824C7CF");

                entity.Property(p => p.IdPlan)
                    .UseIdentityColumn(1, 1);

                entity.Property(p => p.Nombre)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(p => p.DuracionDias)
                    .IsRequired();

                entity.Property(p => p.Precio)
                    .HasPrecision(10, 2)
                    .IsRequired();

                entity.Property(p => p.Descripcion)
                    .HasColumnType("varchar(250)");

                entity.Property(p => p.Activo)
                    .HasDefaultValue(true);
            });

            // INSCRIPCIONES
            modelBuilder.Entity<Inscripcion>(entity =>
            {
                entity.ToTable("Inscripciones", table =>
                {
                    table.HasCheckConstraint(
                        "CK_Inscripciones_Estado",
                        "([Estado]='Cancelada' OR " +
                        "[Estado]='Vencida' OR " +
                        "[Estado]='Activa')");
                });

                entity.HasKey(i => i.IdInscripcion)
                    .HasName("PK__Inscripc__A122F2BF15483972");

                entity.Property(i => i.IdInscripcion)
                    .UseIdentityColumn(1, 1);

                entity.Property(i => i.FechaInicio)
                    .HasColumnType("date")
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(i => i.FechaFin)
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(i => i.Estado)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValue("Activa")
                    .IsRequired();

                // Son propiedades informativas, no columnas SQL.
                entity.Ignore(i => i.NombreCliente);
                entity.Ignore(i => i.NombrePlan);

                entity.HasOne<Cliente>()
                    .WithMany()
                    .HasForeignKey(i => i.IdCliente)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Inscripciones_Clientes");

                entity.HasOne<Plan>()
                    .WithMany()
                    .HasForeignKey(i => i.IdPlan)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Inscripciones_Planes");
            });

            // PAGOS
            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("Pagos", table =>
                {
                    table.HasCheckConstraint(
                        "CK_Pagos_Metodo",
                        "([MetodoPago]='Transferencia' OR " +
                        "[MetodoPago]='Tarjeta' OR " +
                        "[MetodoPago]='Efectivo')");

                    table.HasCheckConstraint(
                        "CK_Pagos_Monto",
                        "([Monto]>(0))");
                });

                entity.HasKey(p => p.IdPago)
                    .HasName("PK__Pagos__FC851A3AE7A63819");

                entity.Property(p => p.IdPago)
                    .UseIdentityColumn(1, 1);

                entity.Property(p => p.Monto)
                    .HasPrecision(10, 2)
                    .IsRequired();

                entity.Property(p => p.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(p => p.MetodoPago)
                    .HasColumnType("varchar(20)")
                    .IsRequired();

                // Son propiedades informativas, no columnas SQL.
                entity.Ignore(p => p.NombreCliente);
                entity.Ignore(p => p.NombrePlan);

                entity.HasOne<Cliente>()
                    .WithMany()
                    .HasForeignKey(p => p.IdCliente)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Pagos_Clientes");

                entity.HasOne<Inscripcion>()
                    .WithMany()
                    .HasForeignKey(p => p.IdInscripcion)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Pagos_Inscripciones");
            });

            // USUARIOS
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios", table =>
                {
                    table.HasCheckConstraint(
                        "CK_Usuarios_Rol",
                        "([Rol]='Empleado' OR " +
                        "[Rol]='Administrador')");
                });

                entity.HasKey(u => u.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97F74D9F6D");

                entity.Property(u => u.IdUsuario)
                    .UseIdentityColumn(1, 1);

                entity.Property(u => u.Nombre)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(u => u.UsuarioNombre)
                    .HasColumnName("Usuario")
                    .HasColumnType("varchar(50)")
                    .IsRequired();

                entity.Property(u => u.ClaveHash)
                    .HasColumnType("varchar(255)")
                    .IsRequired();

                entity.Property(u => u.Rol)
                    .HasColumnType("varchar(20)")
                    .HasDefaultValue("Empleado")
                    .IsRequired();

                entity.Property(u => u.Activo)
                    .HasDefaultValue(true);

                entity.HasIndex(u => u.UsuarioNombre)
                    .IsUnique()
                    .HasDatabaseName("UQ_Usuarios_Usuario");
            });
        }
    }
}
