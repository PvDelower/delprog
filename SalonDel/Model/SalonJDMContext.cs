using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalonDel.Model
{
    public partial class SalonJDMContext : DbContext
    {
        public SalonJDMContext()
        {
        }

        public SalonJDMContext(DbContextOptions<SalonJDMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<CopyCars> CopyCars { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<FormFactor> FormFactor { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Manufactures> Manufactures { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-D5IM4FG\\SQLEXPRESS; Database=SalonJDM; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.CatalogId)
                    .HasName("PK_CARS");

                entity.Property(e => e.CatalogId)
                    .HasColumnName("Catalog_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FormFactorId).HasColumnName("Form_factor_ID");

                entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasOne(d => d.FormFactor)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.FormFactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cars_Form_Factor");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cars_Manufactures");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .HasColumnName("Client_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("Registration_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.ContractId)
                    .HasColumnName("Contract_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdditionalOptions)
                    .HasColumnName("Additional_options")
                    .HasColumnType("text");

                entity.Property(e => e.ClientId).HasColumnName("Client_ID");

                entity.Property(e => e.CopyId).HasColumnName("Copy_ID");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.ManagerId).HasColumnName("Manager_ID");

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasColumnName("Payment_type")
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TypeContract)
                    .IsRequired()
                    .HasColumnName("Type_Contract")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_Clients");

                entity.HasOne(d => d.Copy)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.CopyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_Copy_cars");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contract_managers");
            });

            modelBuilder.Entity<CopyCars>(entity =>
            {
                entity.HasKey(e => e.CopyId);

                entity.ToTable("Copy_cars");

                entity.Property(e => e.CopyId)
                    .HasColumnName("Copy_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Availability)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CatalogId).HasColumnName("Catalog_ID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.EquipmentId).HasColumnName("Equipment_ID");

                entity.Property(e => e.Vin)
                    .IsRequired()
                    .HasColumnName("VIN")
                    .HasMaxLength(17)
                    .IsFixedLength();

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.CopyCars)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Copy_cars_Cars");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.CopyCars)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Copy_cars_Equipment");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.EquipmentId)
                    .HasColumnName("Equipment_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Drive)
                    .IsRequired()
                    .HasColumnName("drive")
                    .HasMaxLength(50);

                entity.Property(e => e.EngineCapacity).HasColumnName("Engine_capacity");

                entity.Property(e => e.TypeEngine)
                    .IsRequired()
                    .HasColumnName("Type_Engine")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FormFactor>(entity =>
            {
                entity.ToTable("Form_Factor");

                entity.Property(e => e.FormFactorId)
                    .HasColumnName("Form_Factor_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.NumberOfDoors).HasColumnName("Number_of_doors");
            });

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.HasKey(e => e.ManegerId);

                entity.ToTable("managers");

                entity.Property(e => e.ManegerId)
                    .HasColumnName("Maneger_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DateRegistration)
                    .HasColumnName("Date_registration")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_name")
                    .HasMaxLength(20);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.LoginNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.Login)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_managers_Users");
            });

            modelBuilder.Entity<Manufactures>(entity =>
            {
                entity.HasKey(e => e.ManufactureId);

                entity.Property(e => e.ManufactureId)
                    .HasColumnName("Manufacture_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Mark)
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Login);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
