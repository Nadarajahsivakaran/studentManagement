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
    public class AllocateSubjectRepository : GenericRepository<AllocateSubject>, IAllocateSubjectRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AllocateSubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Teacher>> TeacherSubject(int id)
        {
            try
            {
                IQueryable<Teacher> query = dbContext.Teacher
                      .Include(t => t.AllocateSubject)
                      .ThenInclude(s => s.Subject);

                if (id != 0)
                {
                    query = query.Where(d => d.TeacherId == id);
                }

                return  await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> RemoveDatas(IEnumerable<AllocateSubject> entities)
        {
            try
            {
                dbContext.AllocateSubject.RemoveRange(entities);
                await dbContext.SaveChangesAsync();
                return true;  
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public async Task<List<AllocateSubject>> GetTeacherAllRecords(int id)
        {
            try
            {
                return await dbContext.AllocateSubject.Where(t => t.TeacherId == id).ToListAsync();

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
