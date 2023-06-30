using StudentManagement.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IClassRoomRepository ClassRoom { get; private set; }

        public IStudentRepository Student { get; private set; }

        public ITeacherRepository Teacher { get; private set; }

        public ISubjectRepository Subject { get; private set; }

        public IAllocateSubjectRepository AllocateSubject { get; private set; }

        public IAllocateClassRoomRepository AllocateClassRoom { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            ClassRoom = new ClassRoomRepository(db);
            Student = new StudentRepository(db);
            Teacher = new TeacherRepository(db);
            Subject = new SubjectRepository(db);
            AllocateSubject = new AllocateSubjectRepository(db);
            AllocateClassRoom = new AllocateClassRoomRepository(db);
        }
    }
}
