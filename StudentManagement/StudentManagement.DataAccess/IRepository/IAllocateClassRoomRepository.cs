using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.IRepository
{
    public interface IAllocateClassRoomRepository : IGenericRepository<AllocateClassRoom>
    {
        Task<IEnumerable<Teacher>> TeacherClassRoom(int id);

        Task<List<AllocateClassRoom>> GetTeacherAllRecords(int id);

        Task<bool> RemoveDatas(IEnumerable<AllocateClassRoom> entities);
    }
}
