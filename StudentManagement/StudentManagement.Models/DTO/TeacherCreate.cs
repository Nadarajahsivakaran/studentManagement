using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DTO
{
    public class TeacherCreate
    {
        [Required, StringLength(30)]
        public string? FirstName { get; set; }

        [Required, StringLength(30)]
        public string? LastName { get; set; }

        [Required, StringLength(15)]
        public string? ContactNo { get; set; }

        [Required, StringLength(30), EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
