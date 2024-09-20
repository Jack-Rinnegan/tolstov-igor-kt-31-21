using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TolstovIgorKt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModelConf2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadLecturerId",
                table: "cd_department");

            migrationBuilder.RenameColumn(
                name: "LecturerId",
                table: "cd_disciplin",
                newName: "lecturer_id");

            migrationBuilder.AlterColumn<int>(
                name: "lecturer_id",
                table: "cd_disciplin",
                type: "integer",
                nullable: false,
                comment: "Идентификатор записи преподавателя",
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lecturer_id",
                table: "cd_disciplin",
                newName: "LecturerId");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerId",
                table: "cd_disciplin",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Идентификатор записи преподавателя");

            migrationBuilder.AddColumn<int>(
                name: "HeadLecturerId",
                table: "cd_department",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
