using StudentManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.IServices
{
   public interface IStudentServices
    {
        IEnumerable<StudentDetails> GetStudent();
        StudentDetails GetStudentById(int studentId);
        void InsertStudent(StudentDetails student);
        void DeleteStudent(int studentId);
        void UpdateStudent(StudentDetails student);
        //string StaffLogin(StaffLoginDetails staffLoginDetail);
    }
}

