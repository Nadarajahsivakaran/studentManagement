using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DTO
{
    public class AllocateClassroomCreate
    {
        [Required]
        public int TeacherId { get; set; }
        public ICollection<ClassRoomIdCollection>? ClassRooms { get; set; }
    }

    public class ClassRoomIdCollection
    {
        [Required]
        public int ClassRoomId { get; set; }
    }
}
