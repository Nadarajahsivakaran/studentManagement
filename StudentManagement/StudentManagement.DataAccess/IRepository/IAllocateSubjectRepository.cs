using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.IRepository
{
    public interface IAllocateSubjectRepository : IGenericRepository<AllocateSubject>
    {
        Task<IEnumerable<Teacher>> TeacherSubject(int id);

        Task<bool> RemoveDatas(IEnumerable<AllocateSubject> entities);

        Task<List<AllocateSubject>> GetTeacherAllRecords(int id);
    }
}
