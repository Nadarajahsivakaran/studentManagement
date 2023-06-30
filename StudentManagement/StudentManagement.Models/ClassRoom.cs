using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    [Table("ClassRooms")]
    public class ClassRoom
    {
        [Key]
        public int ClassroomId { get; set; }

        [Required,StringLength(20)]
        public string? ClassRoomName { get; set; }

        public AllocateClassRoom? AllocateClassRoom { get; set; }
    }
}
