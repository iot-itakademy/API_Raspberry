using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class iot_akademyContext : DbContext
    {
        public iot_akademyContext()
        {
        }

        public iot_akademyContext(DbContextOptions<iot_akademyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sensor> Sensors { get; set; } = null!;
        public virtual DbSet<SensorType> SensorTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=iot_akademy", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.ToTable("sensors");

                entity.HasIndex(e => e.TypeId, "sensors_sensor_type_id_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastEditBy).HasColumnName("last_edit_by");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Params)
                    .HasColumnType("json")
                    .HasColumnName("params");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Sensors)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sensors_sensor_type_id_fk");
            });

            modelBuilder.Entity<SensorType>(entity =>
            {
                entity.ToTable("sensor_type");

                entity.HasIndex(e => e.Id, "sensor_type_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Type, "sensor_type_type_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
