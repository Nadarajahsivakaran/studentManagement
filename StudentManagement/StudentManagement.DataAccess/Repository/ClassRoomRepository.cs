using StudentManagement.DataAccess.IRepository;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Repository
{
    public class ClassRoomRepository : GenericRepository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
