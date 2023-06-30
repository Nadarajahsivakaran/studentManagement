using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using StudentManagement.Models;

namespace StudentManagement.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        public DbSet<ClassRoom> ClassRoom { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Subject> Subject { get; set; }

        public DbSet<AllocateSubject> AllocateSubject { get; set; }

        public DbSet<AllocateClassRoom> AllocateClassRoom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
            // Other configuration options
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClassRoom>().HasData(
                new ClassRoom
                {
                    ClassroomId = 1,
                    ClassRoomName = "Class A",
                },

                 new ClassRoom
                 {
                     ClassroomId = 2,
                     ClassRoomName = "Class B",
                 }
            );

            builder.Entity<Student>().HasData(
                new Student
                {
                    StudentID = 1,
                    FirstName = "Siva",
                    LastName = "Karan",
                    ContactPerson = "Nadarajah",
                    ContactNo = "0773601787",
                    EmailAddress = "karan@gmail.com",
                    DateOfBirth = new DateTime(1995, 10, 9),
                    Age = 28,
                    ClassRoomId = 1
                },

                new Student
                {
                    StudentID = 2,
                    FirstName = "Sivaranjan",
                    LastName = "Kapilan",
                    ContactPerson = "Sivaranjan",
                    ContactNo = "0777456987",
                    EmailAddress = "kapilan@gmail.com",
                    DateOfBirth = new DateTime(1998, 6, 2),
                    Age = 25,
                    ClassRoomId = 2
                }
            );

            builder.Entity<Teacher>().HasData(
                new Teacher
                {
                    TeacherId = 1,
                    FirstName = "Ram",
                    LastName = "Kumar",
                    ContactNo = "0773601787",
                    EmailAddress = "ram@gmail.com"
                },
                new Teacher
                {
                    TeacherId = 2,
                    FirstName = "piraven",
                    LastName = "ramesh",
                    ContactNo = "0773689787",
                    EmailAddress = "piraven@gmail.com"
                }
            );

            builder.Entity<Subject>().HasData(
                new Subject
                {
                    SubjectId = 1,
                    SubjectName = "Maths"
                },
                new Subject
                {
                    SubjectId = 2,
                    SubjectName = "Science"
                }
            );

            builder.Entity<AllocateSubject>().HasData(
                new AllocateSubject
                {
                    AllocateSubjectId = 1,
                    TeacherId = 1,
                    SubjectId = 1,
                },
                new AllocateSubject
                {
                    AllocateSubjectId = 2,
                    TeacherId = 2,
                    SubjectId = 2,
                }
             );

            builder.Entity<AllocateClassRoom>().HasData(
                new AllocateClassRoom
                {
                    AllocateClassRooomId = 1,
                    TeacherId = 1,
                    ClassRoomId = 1
                },
                 new AllocateClassRoom
                 {
                     AllocateClassRooomId = 2,
                     TeacherId = 1,
                     ClassRoomId = 2
                 }
             );


            base.OnModelCreating(builder);
        }
    }
}