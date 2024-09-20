using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TolstovIgorKt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModelConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplins_cd_lecturer_LecturerId",
                table: "Disciplins");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "cd_position");

            migrationBuilder.RenameTable(
                name: "HourlyLoads",
                newName: "cd_hourly_load");

            migrationBuilder.RenameTable(
                name: "Disciplins",
                newName: "cd_disciplin");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "cd_department");

            migrationBuilder.RenameTable(
                name: "AcademicDegrees",
                newName: "cd_academic_degree");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplins_LecturerId",
                table: "cd_disciplin",
                newName: "idx_cd_disciplin_fk_f_lecturer_id");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerId",
                table: "cd_disciplin",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_f_lecturer_id",
                table: "cd_disciplin",
                column: "LecturerId",
                principalTable: "cd_lecturer",
                principalColumn: "lecturer_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_f_lecturer_id",
                table: "cd_disciplin");

            migrationBuilder.RenameTable(
                name: "cd_position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "cd_hourly_load",
                newName: "HourlyLoads");

            migrationBuilder.RenameTable(
                name: "cd_disciplin",
                newName: "Disciplins");

            migrationBuilder.RenameTable(
                name: "cd_department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "cd_academic_degree",
                newName: "AcademicDegrees");

            migrationBuilder.RenameIndex(
                name: "idx_cd_disciplin_fk_f_lecturer_id",
                table: "Disciplins",
                newName: "IX_Disciplins_LecturerId");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerId",
                table: "Disciplins",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplins_cd_lecturer_LecturerId",
                table: "Disciplins",
                column: "LecturerId",
                principalTable: "cd_lecturer",
                principalColumn: "lecturer_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
