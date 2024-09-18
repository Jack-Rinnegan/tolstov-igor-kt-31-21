using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public const string TableName = "cd_position";

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder
                .HasKey(p => p.PositionId)
                .HasName($"pk_{TableName}_position_id");

            builder.Property(p => p.PositionId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.PositionId)
                .HasColumnName("position_id")
                .HasComment("Идентификатор записи должности");

            builder.Property(p => p.PositionName)
                .IsRequired()
                .HasColumnName("c_position_name")
                .HasComment("Наименование должности");

        }
    }
}
