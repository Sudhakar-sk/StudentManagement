using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Core.IRepositories;
using StudentManagement.Core.IServices;
using StudentManagement.Core.Models;


namespace StudentManagement.Services.Services
{
    public class StudentServices : IStudentServices
    {
        
        readonly IStudentRepositories _IStudentRepositories;
      
        public StudentServices(IStudentRepositories StudentRepositories)
        {
            _IStudentRepositories = StudentRepositories;
        }


       public IEnumerable<StudentDetails> GetStudent()
        {
            return _IStudentRepositories.GetStudent();
        }


       public StudentDetails GetStudentById(int studentId) 
        {
           return _IStudentRepositories.GetStudentById(studentId);
        }
       public void InsertStudent(StudentDetails student)
        {
            _IStudentRepositories.InsertStudent(student);
        }
       public void DeleteStudent(int studentId)
        {
            _IStudentRepositories.DeleteStudent(studentId);
        }
       public void UpdateStudent(StudentDetails student) 
        {
            _IStudentRepositories.UpdateStudent(student);
        }
        
    }
}
