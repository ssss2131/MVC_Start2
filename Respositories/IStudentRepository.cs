using System.Collections;
using System.Collections.Generic;

namespace MVC_Start.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// 通过学生Id获取某一学生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetStudent(int id);

        IEnumerable<Student> GetStuList();

        Student AddStu(Student stu);

        int Count();

        Student Update(Student UpStu);

        Student Delete(int id);

    }
}
