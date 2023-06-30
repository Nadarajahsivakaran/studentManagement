using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class allocate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllocateSubjectMyProperty",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AllocateSubject",
                columns: table => new
                {
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocateSubject", x => x.MyProperty);
                    table.ForeignKey(
                        name: "FK_AllocateSubject_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 1,
                column: "AllocateSubjectMyProperty",
                value: null);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 2,
                column: "AllocateSubjectMyProperty",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AllocateSubjectMyProperty",
                table: "Subjects",
                column: "AllocateSubjectMyProperty");

            migrationBuilder.CreateIndex(
                name: "IX_AllocateSubject_TeacherId",
                table: "AllocateSubject",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AllocateSubject_AllocateSubjectMyProperty",
                table: "Subjects",
                column: "AllocateSubjectMyProperty",
                principalTable: "AllocateSubject",
                principalColumn: "MyProperty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AllocateSubject_AllocateSubjectMyProperty",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "AllocateSubject");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_AllocateSubjectMyProperty",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AllocateSubjectMyProperty",
                table: "Subjects");
        }
    }
}
