using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using StudentManagement.Core.Models;
using StudentManagement.Core.IServices;


namespace StudentManagement.Web.Controllers
{
    public class StudentController1 : Controller
    {

        #region Declaration
        private readonly IStudentServices _IStudentServices;
        #endregion

        #region Constructor
        public StudentController1(IStudentServices StudentServices)
        {
            _IStudentServices = StudentServices;
        }
        #endregion
        #region view page list
        public IActionResult Index()
        {
            var Students = _IStudentServices.GetStudent();
            return View(Students);
        }
        #endregion
        #region Create
        public ActionResult Create()
        {
            return View("CreateEdit", new StudentDetails());
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            StudentDetails model = _IStudentServices.GetStudentById(id);
            return View("CreateEdit", model);
        }
        #endregion
        #region Delete
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                StudentDetails student = new StudentDetails();
                student = _IStudentServices.GetStudentById(id);
                _IStudentServices.DeleteStudent(id);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region CreateEdit
        [HttpPost]
        public ActionResult CreateEdit(StudentDetails student)
        {
            if (student.StudentId == 0) 
            {              
                    _IStudentServices.InsertStudent(student);
            }
            else
            {
                _IStudentServices.UpdateStudent(student);
            }
            return RedirectToAction("index");
        }
        #endregion

        #region Commented
        //[HttpPost]
        //public ActionResult Create(StudentDetails student)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _IStudentServices.InsertStudent(student);
        //             return RedirectToAction("Index");
        //        }
        //    }
        //    catch (DataException)
        //    {
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //    }
        //    return RedirectToAction("CreateEdit",student);
        //}




        //[HttpPost]

        //public ActionResult Edit(StudentDetails Student)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _IStudentServices.UpdateStudent(Student);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (DataException)
        //    {
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
        //    }
        //    return RedirectToAction("CreateEdit",Student);
        //}

        #endregion
        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StaffLogin(StaffLoginDetails staffLoginDetail)
        {
            if (staffLoginDetail.UserName == "Sudhakar" && staffLoginDetail.Password == "pass123")
            {
                TempData["LoginAlert"] = "Login Successfully";
                return RedirectToAction("index");
            }
            else if (staffLoginDetail.UserName != "Sudhakar" || staffLoginDetail.Password != "pass123")
            {
                TempData["LoginAlert"] = "Enter Correct Detail";
                return RedirectToAction("StaffLogin");
            }
            return View();

        }
        #endregion
    }
}
