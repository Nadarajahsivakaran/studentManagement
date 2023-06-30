using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addclassroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllocateClassRooms",
                columns: table => new
                {
                    AllocateClassRooomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocateClassRooms", x => x.AllocateClassRooomId);
                    table.ForeignKey(
                        name: "FK_AllocateClassRooms_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "ClassroomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllocateClassRooms_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AllocateClassRooms",
                columns: new[] { "AllocateClassRooomId", "ClassRoomId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllocateClassRooms_ClassRoomId",
                table: "AllocateClassRooms",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocateClassRooms_TeacherId",
                table: "AllocateClassRooms",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllocateClassRooms");
        }
    }
}
