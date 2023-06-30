using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DTO
{
    public class ClassRoomCreate
    {

        [Required, StringLength(20)]
        public string? ClassRoomName { get; set; }
    }
}
