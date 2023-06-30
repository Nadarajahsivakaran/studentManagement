using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        public IClassRoomRepository ClassRoom { get; }

        public IStudentRepository Student { get; }

        public ITeacherRepository Teacher { get; }

        public ISubjectRepository Subject { get; }

        public IAllocateSubjectRepository AllocateSubject { get; }

        public IAllocateClassRoomRepository AllocateClassRoom { get; }
    }
}
