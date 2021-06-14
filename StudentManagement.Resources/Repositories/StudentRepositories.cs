using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Core.IRepositories;
using StudentManagement.Entities;
using StudentManagement.Core.Models;


namespace StudentManagement.Resources.Repositories
{
    public class StudentRepositories: IStudentRepositories
    {
      
        #region To get student details from DB Table to Model
        public IEnumerable<StudentDetails> GetStudent()
        {
            IList<StudentDetails> studentList = new List<StudentDetails>();
            var StudentDB = new StudentMangementDBContext() ;
            var query = from student in StudentDB.student_Detail_Table
                        where student.Is_Deleted==false
                        select student ;
            var students = query.ToList();

            foreach (var studentData in students)
            {
                studentList.Add(new StudentDetails()
                {
                    StudentId = studentData.Student_Id,
                    FirstName = studentData.First_Name,
                    LastName = studentData.Last_Name,
                    DateOfBirth = studentData.Date_of_Birth,
                    Age = studentData.Age,
                    FavoriteSubject = studentData.Favorite_Subject,
                    InterstedCourse = studentData.Intersted_Course,
                    MathsMark = studentData.Maths_Mark,
                    ChemistryMark = studentData.Chemistry_Mark,
                    ComputerScienceMark = studentData.Computer_Science_Mark
                });
            }
            return studentList;
        }
        #endregion

        #region get student detail by using student Id
        public StudentDetails GetStudentById(int studentId)
        {
            var StudentDB = new StudentMangementDBContext();
            var query = from student in StudentDB.student_Detail_Table
                        where student.Student_Id == studentId
                        select student;
            var studentData = query.FirstOrDefault();
            var model = new StudentDetails()
            {
                StudentId = studentData.Student_Id,
                FirstName = studentData.First_Name,
                LastName = studentData.Last_Name,
                DateOfBirth = studentData.Date_of_Birth,
                Age = studentData.Age,
                FavoriteSubject = studentData.Favorite_Subject,
                InterstedCourse = studentData.Intersted_Course,
                MathsMark = studentData.Maths_Mark,
                ChemistryMark = studentData.Chemistry_Mark,
                ComputerScienceMark = studentData.Computer_Science_Mark
            };
            return model;
        }
        #endregion

        #region InsertStudentDetails
        public void InsertStudent(StudentDetails student)
        {
            var StudentDB = new StudentMangementDBContext();
            var studentData = new student_Detail_Table()
            {
                Student_Id = student.StudentId,
                First_Name = student.FirstName,
                Last_Name = student.LastName,
                Date_of_Birth = student.DateOfBirth,
                Age = student.Age,
                Favorite_Subject = student.FavoriteSubject,
                Intersted_Course = student.InterstedCourse,
                Maths_Mark = student.MathsMark,
                Chemistry_Mark = student.ChemistryMark,
                Computer_Science_Mark = student.ComputerScienceMark
            };
            StudentDB.student_Detail_Table.Add(studentData);
            StudentDB.SaveChanges();
        }
        #endregion

        #region Delete Student Details from the DB
        public void DeleteStudent(int studentId)
        {
            var StudentDB = new StudentMangementDBContext();
            var student = StudentDB.student_Detail_Table.Where(x => x.Student_Id == studentId&& x.Is_Deleted==false).SingleOrDefault();
            if (student != null)
            {
                student.Is_Deleted = true;
                student.Update_Time_stamp = DateTime.Now;
                StudentDB.SaveChanges();
            }


        }
        #endregion

        #region update Student Details
        public void UpdateStudent(StudentDetails student)
        {
            int id = student.StudentId;
            var StudentDB = new StudentMangementDBContext();
            var studentData = StudentDB.student_Detail_Table.Where(x => x.Student_Id == id && x.Is_Deleted==false).SingleOrDefault();
            studentData.Student_Id = student.StudentId;
            studentData.First_Name = student.FirstName;
            studentData.Last_Name = student.LastName;
            studentData.Date_of_Birth = student.DateOfBirth;
            studentData.Age = student.Age;
            studentData.Favorite_Subject = student.FavoriteSubject;
            studentData.Intersted_Course = student.InterstedCourse;
            studentData.Maths_Mark = student.MathsMark;
            studentData.Chemistry_Mark = student.ChemistryMark;
            studentData.Computer_Science_Mark = student.ComputerScienceMark;
            studentData.Update_Time_stamp = DateTime.Now;
            StudentDB.SaveChanges();
        }
        #endregion

        #region StaffLogin
      
#endregion
    }

}
