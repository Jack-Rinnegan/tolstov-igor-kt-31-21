using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TolstovIgorKt_31_21.Database.Helprers;
using TolstovIgorKt_31_21.Models;

namespace TolstovIgorKt_31_21.Database.Configurations
{
    public class AcademicDegreeConfiguration: IEntityTypeConfiguration<AcademicDegree>
    {
        public const string TableName = "cd_academic_degree";

        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder
                .HasKey(p => p.AcademicDegreeId)
                .HasName($"pk_{TableName}_academic_degree_id");

            builder.Property(p => p.AcademicDegreeId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.AcademicDegreeId)
                .HasColumnName("academic_degree_id")
                .HasComment("Идентификатор записи ученой степени");

            builder.Property(p => p.AcademicDegreeName)
                .IsRequired()
                .HasColumnName("c_academic_degree_name")
                .HasColumnType(ColumnType.String).HasMaxLength(128)
                .HasComment("Наименование ученой степени");

            builder.ToTable(TableName);

        }
    }
}
