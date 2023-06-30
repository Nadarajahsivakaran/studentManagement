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
    public class AllocateClassRoomRepository : GenericRepository<AllocateClassRoom>, IAllocateClassRoomRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AllocateClassRoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Teacher>> TeacherClassRoom(int id)
        {

            try
            {
                IQueryable<Teacher> query =  dbContext.Teacher;
                if(id!=0)
                {
                    query = query.Where(t => t.TeacherId==id);
                }
                query = query.Include(t => t.AllocateClassRoom).ThenInclude(c=>c.ClassRoom);
                return await query.ToListAsync();


            }catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<AllocateClassRoom>> GetTeacherAllRecords(int id)
        {
            try
            {
                return await dbContext.AllocateClassRoom.Where(t => t.TeacherId == id).ToListAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> RemoveDatas(IEnumerable<AllocateClassRoom> entities)
        {
            try
            {
                dbContext.AllocateClassRoom.RemoveRange(entities);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
