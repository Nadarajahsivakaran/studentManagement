using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required, StringLength(20)]
        public string? SubjectName { get; set; }

        public ICollection<AllocateSubject>? AllocateSubject { get; set; }
    }
}
