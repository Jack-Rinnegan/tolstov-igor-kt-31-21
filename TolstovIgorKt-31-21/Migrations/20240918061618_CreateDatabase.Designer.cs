﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TolstovIgorKt_31_21.Database;

#nullable disable

namespace TolstovIgorKt_31_21.Migrations
{
    [DbContext(typeof(LecturerDbContext))]
    [Migration("20240918061618_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.AcademicDegree", b =>
                {
                    b.Property<int>("AcademicDegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("academic_degree_id")
                        .HasComment("Идентификатор записи ученой степени");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AcademicDegreeId"));

                    b.Property<int>("AcademicDegreeName")
                        .HasColumnType("integer")
                        .HasColumnName("c_academic_degree_name")
                        .HasComment("Наименование ученой степени");

                    b.HasKey("AcademicDegreeId")
                        .HasName("pk_cd_academic_degree_academic_degree_id");

                    b.ToTable("AcademicDegrees");
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор записи кафедры");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar")
                        .HasColumnName("c_department_name")
                        .HasComment("Название кафедры");

                    b.Property<int>("HeadLecturerId")
                        .HasColumnType("integer");

                    b.HasKey("DepartmentId")
                        .HasName("pk_cd_department_department_id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.Disciplin", b =>
                {
                    b.Property<int>("DisciplinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("disciplin_id")
                        .HasComment("Идентификатор записи предмета");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DisciplinId"));

                    b.Property<string>("DisciplinName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar")
                        .HasColumnName("c_disciplin_name")
                        .HasComment("Название предмета");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("integer");

                    b.HasKey("DisciplinId")
                        .HasName("pk_cd_disciplin_disciplin_id");

                    b.HasIndex("LecturerId");

                    b.ToTable("Disciplins");
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.HourlyLoad", b =>
                {
                    b.Property<int>("HourlyLoadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("hourly_load_id")
                        .HasComment("Идентификатор записи звгруженности преподавателя");

                    b.Property<int>("Hours")
                        .HasMaxLength(8)
                        .HasColumnType("int4")
                        .HasColumnName("c_hours")
                        .HasComment("Количество часов");

                    b.HasKey("HourlyLoadId")
                        .HasName("pk_cd_hourly_load_hourly_load_id");

                    b.ToTable("HourlyLoads");
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.Lecturer", b =>
                {
                    b.Property<int>("LecturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("lecturer_id")
                        .HasComment("Идентификатор записи преподавателя");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LecturerId"));

                    b.Property<int>("AcademicDegreeId")
                        .HasColumnType("integer")
                        .HasColumnName("academic_degree_id")
                        .HasComment("Идентификатор записи ученой степени");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор записи кафедры");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar")
                        .HasColumnName("c_lecturer_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<int>("HourlyLoadId")
                        .HasColumnType("integer")
                        .HasColumnName("hourly_load_id")
                        .HasComment("Идентификатор загруженности преподавателя");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar")
                        .HasColumnName("c_lecturer_lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar")
                        .HasColumnName("c_lecturer_middlename")
                        .HasComment("Отчество преподавателя");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer")
                        .HasColumnName("position_id")
                        .HasComment("Идентификатор записи должности");

                    b.HasKey("LecturerId")
                        .HasName("pk_cd_lecturer_lecturer_id");

                    b.HasIndex(new[] { "AcademicDegreeId" }, "idx_cd_lecturer_fk_f_academic_degree_id");

                    b.HasIndex(new[] { "DepartmentId" }, "idx_cd_lecturer_fk_f_department_id");

                    b.HasIndex(new[] { "HourlyLoadId" }, "idx_cd_lecturer_fk_f_hourly_load_id");

                    b.HasIndex(new[] { "PositionId" }, "idx_cd_lecturer_fk_f_position_id");

                    b.ToTable("cd_lecturer", (string)null);
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("position_id")
                        .HasComment("Идентификатор записи должности");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PositionId"));

                    b.Property<int>("PositionName")
                        .HasColumnType("integer")
                        .HasColumnName("c_position_name")
                        .HasComment("Наименование должности");

                    b.HasKey("PositionId")
                        .HasName("pk_cd_position_position_id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.Disciplin", b =>
                {
                    b.HasOne("TolstovIgorKt_31_21.Models.Lecturer", null)
                        .WithMany("Disciplines")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.HourlyLoad", b =>
                {
                    b.HasOne("TolstovIgorKt_31_21.Models.Lecturer", null)
                        .WithOne("HourlyLoad")
                        .HasForeignKey("TolstovIgorKt_31_21.Models.HourlyLoad", "HourlyLoadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_hourly_load_id");
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.Lecturer", b =>
                {
                    b.HasOne("TolstovIgorKt_31_21.Models.AcademicDegree", "AcademicDegree")
                        .WithMany()
                        .HasForeignKey("AcademicDegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_academic_degree_id");

                    b.HasOne("TolstovIgorKt_31_21.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_department_id");

                    b.HasOne("TolstovIgorKt_31_21.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_position_id");

                    b.Navigation("AcademicDegree");

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("TolstovIgorKt_31_21.Models.Lecturer", b =>
                {
                    b.Navigation("Disciplines");

                    b.Navigation("HourlyLoad")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
