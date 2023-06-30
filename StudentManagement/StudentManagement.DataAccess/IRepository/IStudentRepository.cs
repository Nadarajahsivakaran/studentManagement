﻿using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.IRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetReport(int id);
    }
}
