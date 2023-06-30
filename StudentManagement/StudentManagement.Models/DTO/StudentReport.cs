using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DTO
{
    public class StudentReport
    {
        public Student Student { get; set; }

        public Teacher Teacher { get; set; }
    }
}
