
using MVC_Start.Models;
using System.Collections.Generic;

namespace MVC_Start.Respositories
{
    public class SqlServerRepository:IStudentRepository
    {
        private readonly AppDbContext _context;
        public SqlServerRepository(AppDbContext Context)
        {
            _context = Context;
        }

        public Student AddStu(Student stu)
        {
            _context.Students.Add(stu);
            _context.SaveChanges();
            return stu;
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public Student Delete(int id)
        {
            Student stu = _context.Students.Find(id);
            if (stu != null)
            { 
                _context.Students.Remove(stu);
                _context.SaveChanges();
            }
            return stu;
            
        }

        public Student GetStudent(int id)
        {
            Student student = _context.Students.Find(id);
            return student;
        }

        public IEnumerable<Student> GetStuList()
        {
            return _context.Students;
        }

        public Student Update(Student UpStu)
        {
            var stu = _context.Students.Attach(UpStu);
            stu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return UpStu;
        }
    }
}
