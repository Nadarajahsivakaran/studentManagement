using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    [Table("AllocateSubject")]
    public class AllocateSubject
    {
        [Key]
        public int AllocateSubjectId { get; set; }

        [Required] 
        public int TeacherId { get; set;}
        public Teacher? Teacher { get; set; }

        [Required]
        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }


    }
}
