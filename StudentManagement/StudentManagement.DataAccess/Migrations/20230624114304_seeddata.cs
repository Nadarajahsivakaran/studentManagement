using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "ClassroomId", "ClassRoomName" },
                values: new object[,]
                {
                    { 1, "Class A" },
                    { 2, "Class B" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Age", "ClassRoomId", "ContactNo", "ContactPerson", "DateOfBirth", "EmailAddress", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 28, 1, "0773601787", "Nadarajah", new DateTime(1995, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "karan@gmail.com", "Siva", "Karan" },
                    { 2, 25, 2, "0777456987", "Sivaranjan", new DateTime(1998, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "kapilan@gmail.com", "Sivaranjan", "Kapilan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "ClassroomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "ClassroomId",
                keyValue: 2);
        }
    }
}
