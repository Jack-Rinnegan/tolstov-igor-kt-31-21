using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TolstovIgorKt_31_21.Database.Helprers;
using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Database.Configurations
{
    public class DisciplinConfiguration : IEntityTypeConfiguration<Disciplin>
    {
        public const string TableName = "cd_disciplin";

        public void Configure(EntityTypeBuilder<Disciplin> builder)
        {
            builder
                .HasKey(p => p.DisciplinId)
                .HasName($"pk_{TableName}_disciplin_id");

            builder.Property(p => p.DisciplinId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DisciplinId)
                .HasColumnName("disciplin_id")
                .HasComment("Идентификатор записи предмета");

            builder.Property(p => p.DisciplinName)
                .IsRequired()
                .HasColumnName("c_disciplin_name")
                .HasColumnType(ColumnType.String).HasMaxLength(128)
                .HasComment("Название предмета");

        }
    }
}
