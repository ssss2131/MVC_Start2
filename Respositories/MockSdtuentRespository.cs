using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Start.Models
{
    /// <summary>
    /// 
    /// </summary>

    public class MockSdtuentRespository : IStudentRepository
    {
        //模拟数据库
        private List<Student> _studentsList;
        public MockSdtuentRespository()
        {
            _studentsList = new List<Student>()
            {
                new Student(){ Id = 1,Name = "张三",Major=MajorEnum.computer_Science,Email="zhangsan@qq.com"},
                new Student(){ Id = 2,Name = "李四",Major=MajorEnum.logistics,Email="lisi@qq.com"},
                new Student(){ Id = 3,Name = "王五",Major=MajorEnum.Electronic_Commerce,Email="wangwu@qq.com"},
                new Student(){ Id = 4,Name = "老六",Major=MajorEnum.economics,Email="laoliu@qq.com"}
            };           
        }

        public Student GetStudent(int id)
        {
            return _studentsList.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Student> GetStuList()
        {
            return _studentsList;
        }

        public Student AddStu(Student stu)
        {
            stu.Id = _studentsList.Max(s=>s.Id)+1;
            _studentsList.Add(stu);
            return stu;
        }

        public int Count()
        {           
            return _studentsList.Count;
        }

        public Student Update(Student UpStu)
        {
            var stu = new Student();
            stu.Id = UpStu.Id;
            stu.Name = UpStu.Name;  
            stu.Email = UpStu.Email;
            return stu;
        }

        public Student Delete(int id)
        {
            var student = _studentsList.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _studentsList.Remove(student);
            }
            return student;
        }
    }
}
