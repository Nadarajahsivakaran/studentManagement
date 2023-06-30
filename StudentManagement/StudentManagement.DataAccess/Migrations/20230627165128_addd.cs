using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AllocateSubject_AllocateSubjectId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_AllocateSubjectId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AllocateSubjectId",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "AllocateSubject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AllocateSubject",
                columns: new[] { "AllocateSubjectId", "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllocateSubject_SubjectId",
                table: "AllocateSubject",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocateSubject_Subjects_SubjectId",
                table: "AllocateSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocateSubject_Subjects_SubjectId",
                table: "AllocateSubject");

            migrationBuilder.DropIndex(
                name: "IX_AllocateSubject_SubjectId",
                table: "AllocateSubject");

            migrationBuilder.DeleteData(
                table: "AllocateSubject",
                keyColumn: "AllocateSubjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AllocateSubject",
                keyColumn: "AllocateSubjectId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "AllocateSubject");

            migrationBuilder.AddColumn<int>(
                name: "AllocateSubjectId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 1,
                column: "AllocateSubjectId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 2,
                column: "AllocateSubjectId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_AllocateSubjectId",
                table: "Subjects",
                column: "AllocateSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AllocateSubject_AllocateSubjectId",
                table: "Subjects",
                column: "AllocateSubjectId",
                principalTable: "AllocateSubject",
                principalColumn: "AllocateSubjectId");
        }
    }
}
