using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required,StringLength(30)]
        public string? FirstName { get; set;}

        [Required, StringLength(30)]
        public string? LastName { get; set; }

        [Required, StringLength(30)]
        public string? ContactPerson { get; set; }

        [Required, StringLength(15)]
        public string? ContactNo { get; set; }

        [Required,StringLength(30),EmailAddress]
        public string? EmailAddress { get; set; }

        [Required,DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required,Range(0,100)]
        public int Age { get; set; }

        [Required]
        public int ClassRoomId { get; set; }
        public ClassRoom? ClassRoom { get; set;}
    }
}