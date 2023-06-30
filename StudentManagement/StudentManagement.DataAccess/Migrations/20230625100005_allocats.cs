using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class allocats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AllocateSubject_AllocateSubjectMyProperty",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "AllocateSubjectMyProperty",
                table: "Subjects",
                newName: "AllocateSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_AllocateSubjectMyProperty",
                table: "Subjects",
                newName: "IX_Subjects_AllocateSubjectId");

            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "AllocateSubject",
                newName: "AllocateSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AllocateSubject_AllocateSubjectId",
                table: "Subjects",
                column: "AllocateSubjectId",
                principalTable: "AllocateSubject",
                principalColumn: "AllocateSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AllocateSubject_AllocateSubjectId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "AllocateSubjectId",
                table: "Subjects",
                newName: "AllocateSubjectMyProperty");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_AllocateSubjectId",
                table: "Subjects",
                newName: "IX_Subjects_AllocateSubjectMyProperty");

            migrationBuilder.RenameColumn(
                name: "AllocateSubjectId",
                table: "AllocateSubject",
                newName: "MyProperty");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AllocateSubject_AllocateSubjectMyProperty",
                table: "Subjects",
                column: "AllocateSubjectMyProperty",
                principalTable: "AllocateSubject",
                principalColumn: "MyProperty");
        }
    }
}
