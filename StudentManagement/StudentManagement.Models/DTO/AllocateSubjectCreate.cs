using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DTO
{
    public class AllocateSubjectCreate
    {
        [Required]
        public int TeacherId { get; set; }

        public ICollection<SubjectIdCollection>? Subjects { get; set; }
    }

    public class SubjectIdCollection
    {
        [Required]
        public int SubjectId { get; set; }
    }
}
