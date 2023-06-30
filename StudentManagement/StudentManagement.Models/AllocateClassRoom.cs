using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    [Table("AllocateClassRooms")]
    public class AllocateClassRoom
    {
        [Key] 
        public int AllocateClassRooomId { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        [Required]
        public int ClassRoomId { get; set; }
        public ClassRoom? ClassRoom { get; set; }
    }
}
