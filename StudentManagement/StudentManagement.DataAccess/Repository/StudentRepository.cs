using Microsoft.EntityFrameworkCore;
using StudentManagement.DataAccess.IRepository;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> GetReport(int id)
        {
            try
            {
               return await  _dbContext.Student
                    .Where(s=>s.StudentID==id)
                    .Include(c=>c.ClassRoom)
                    .ThenInclude(a=>a.AllocateClassRoom)
                    .ThenInclude(t=>t.Teacher)
                    .FirstOrDefaultAsync();

                

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while GetReport: {ex.Message}");
                throw;
            }
        }
    }
}
