using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TolstovIgorKt_31_21.Database.Helprers;
using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Database.Configurations
{
    public class HourlyLoadConfiguration : IEntityTypeConfiguration<HourlyLoad>
    {
        public const string TableName = "cd_hourly_load";

        public void Configure(EntityTypeBuilder<HourlyLoad> builder)
        {
            builder
                .HasKey(p => p.HourlyLoadId)
                .HasName($"pk_{TableName}_hourly_load_id");

            builder.Property(p => p.HourlyLoadId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.HourlyLoadId)
                .HasColumnName("hourly_load_id")
                .HasComment("Идентификатор записи звгруженности преподавателя");

            builder.Property(p => p.Hours)
                .IsRequired()
                .HasColumnName("c_hours")
                .HasColumnType(ColumnType.Int).HasMaxLength(8)
                .HasComment("Количество часов");

        }
    }
}
