using System;
using System.Collections.Generic;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api_Raspberry.DataAccess.DataObjects
{
    public partial class iot_akademyContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public iot_akademyContext()
        {

        }

        public iot_akademyContext(DbContextOptions<iot_akademyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Badge> Badges { get; set; } = null!;
        public virtual DbSet<Entry> Entries { get; set; } = null!;
        public virtual DbSet<GlobalSetting> GlobalSettings { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sensor> Sensors { get; set; } = null!;
        public virtual DbSet<Statistic> Statistics { get; set; } = null!;
        public virtual DbSet<SensorType> SensorTypes { get; set; } = null!;
        public virtual DbSet<SurveyMode> SurveyModes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=82.65.209.20;port=3306;user=service_iot;password=oM5fE5viesrZrS3fhak9o7Qpbd9Q;database=iot_akademy_dev", ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.ToTable("badges");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("entry");

                entity.HasIndex(e => e.Id, "table_name_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FileName)
                    .HasMaxLength(250)
                    .HasColumnName("file_name");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<GlobalSetting>(entity =>
            {
                entity.ToTable("global_settings");

                entity.HasIndex(e => e.LastEditBy, "global_settings_user_id_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountCapture).HasColumnName("amount_capture");

                entity.Property(e => e.LastEditBy).HasColumnName("last_edit_by");

                entity.Property(e => e.SurveyModeId).HasColumnName("survey_mode_id");

                entity.Property(e => e.TimeZone)
                    .HasMaxLength(150)
                    .HasColumnName("time_zone");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

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

            modelBuilder.Entity<SurveyMode>(entity =>
            {
                entity.ToTable("survey_mode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastEditBy).HasColumnName("last_edit_by");

                entity.Property(e => e.Params)
                    .HasColumnType("json")
                    .HasColumnName("params");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Email, "UNIQ_8D93D649E7927C74")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(150)
                    .HasColumnName("city");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("(DC2Type:datetime_immutable)");

                entity.Property(e => e.Email)
                    .HasMaxLength(180)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .HasColumnName("firstname");

                entity.Property(e => e.GoogleAuthenticatorSecret)
                    .HasMaxLength(255)
                    .HasColumnName("google_authenticator_secret");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Roles)
                    .HasColumnType("json")
                    .HasColumnName("roles");

                entity.Property(e => e.Zipcode)
                    .HasMaxLength(5)
                    .HasColumnName("zipcode");
            });

            modelBuilder.Entity<Statistic>(entity =>
            {
                entity.ToTable("statistics");

                entity.HasIndex(e => e.Id, "statistics_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
