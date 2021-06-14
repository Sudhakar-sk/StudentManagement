using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Core.Models;

namespace StudentManagement.Core.IRepositories
{
   public interface IStudentRepositories
    {
        IEnumerable<StudentDetails> GetStudent();
        StudentDetails GetStudentById(int studentId);
        void InsertStudent(StudentDetails student);
        void DeleteStudent(int studentId);
        void UpdateStudent(StudentDetails student);
        //string StaffLogin(StaffLoginDetails staffLoginDetail);
    }
}
