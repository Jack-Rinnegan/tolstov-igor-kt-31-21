using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TolstovIgorKt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи ученой степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_academic_degree_name = table.Column<string>(type: "varchar", maxLength: 128, nullable: false, comment: "Наименование ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 128, nullable: false, comment: "Название кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_position_name = table.Column<string>(type: "varchar", maxLength: 128, nullable: false, comment: "Наименование должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_lecturer",
                columns: table => new
                {
                    lecturer_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_lecturer_firstname = table.Column<string>(type: "varchar", maxLength: 128, nullable: false, comment: "Имя преподавателя"),
                    c_lecturer_lastname = table.Column<string>(type: "varchar", maxLength: 128, nullable: false, comment: "Фамилия преподавателя"),
                    c_lecturer_middlename = table.Column<string>(type: "varchar", maxLength: 128, nullable: false, comment: "Отчество преподавателя"),
                    academic_degree_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи ученой степени"),
                    position_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи должности"),
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_lecturer_lecturer_id", x => x.lecturer_id);
                    table.ForeignKey(
                        name: "fk_f_academic_degree_id",
                        column: x => x.academic_degree_id,
                        principalTable: "cd_academic_degree",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.department_id,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_position_id",
                        column: x => x.position_id,
                        principalTable: "cd_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_disciplin",
                columns: table => new
                {
                    disciplin_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_disciplin_name = table.Column<string>(type: "varchar", maxLength: 128, nullable: false, comment: "Название предмета"),
                    lecturer_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_disciplin_disciplin_id", x => x.disciplin_id);
                    table.ForeignKey(
                        name: "fk_f_lecturer_id",
                        column: x => x.lecturer_id,
                        principalTable: "cd_lecturer",
                        principalColumn: "lecturer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_hourly_load",
                columns: table => new
                {
                    hourly_load_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи звгруженности преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_hours = table.Column<int>(type: "int4", maxLength: 8, nullable: false, comment: "Количество часов"),
                    lecturer_id = table.Column<int>(type: "integer", nullable: true, comment: "Идентификатор записи преподавателя"),
                    department_id = table.Column<int>(type: "integer", nullable: true, comment: "Идентификатор записи кафедры"),
                    disciplin_id = table.Column<int>(type: "integer", nullable: true, comment: "Идентификатор записи дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_hourly_load_hourly_load_id", x => x.hourly_load_id);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.department_id,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_disciplin_id",
                        column: x => x.disciplin_id,
                        principalTable: "cd_disciplin",
                        principalColumn: "disciplin_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_lecturer_id",
                        column: x => x.lecturer_id,
                        principalTable: "cd_lecturer",
                        principalColumn: "lecturer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_disciplin_fk_f_lecturer_id",
                table: "cd_disciplin",
                column: "lecturer_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_hourly_load_fk_f_department_id",
                table: "cd_hourly_load",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_hourly_load_fk_f_disciplin_id",
                table: "cd_hourly_load",
                column: "disciplin_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_hourly_load_fk_f_lecturer_id",
                table: "cd_hourly_load",
                column: "lecturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_hourly_load_department_id",
                table: "cd_hourly_load",
                column: "department_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cd_hourly_load_disciplin_id",
                table: "cd_hourly_load",
                column: "disciplin_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cd_hourly_load_lecturer_id",
                table: "cd_hourly_load",
                column: "lecturer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_lecturer_fk_f_academic_degree_id",
                table: "cd_lecturer",
                column: "academic_degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_lecturer_fk_f_department_id",
                table: "cd_lecturer",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_lecturer_fk_f_position_id",
                table: "cd_lecturer",
                column: "position_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_hourly_load");

            migrationBuilder.DropTable(
                name: "cd_disciplin");

            migrationBuilder.DropTable(
                name: "cd_lecturer");

            migrationBuilder.DropTable(
                name: "cd_academic_degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
