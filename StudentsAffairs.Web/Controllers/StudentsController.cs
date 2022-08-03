using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsAffairs.Core.IServices;
using StudentsAffairs.Models;
using StudentsAffairs.ViewModels;
using System;
using System.Threading.Tasks;
using static StudentsAffairs.Models.Enums;

namespace StudentsAffairs.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IClassService _classService;

        public StudentsController(
            IStudentService studentService,
            IClassService classService
            )
        {
            _studentService = studentService;
            _classService = classService;
        }

        public async Task<IActionResult> Index(
            string className = null,
            int currentPage = 1, int maxRows = 2,
            string searchBtn = null
            )
        {
            try
            {
                StudentViewModel studentViewModel = new StudentViewModel();
                studentViewModel.StudentFilter = new StudentFilter();
                studentViewModel.StudentFilter.ClassName = className;
                studentViewModel.StudentFilter.CurrentPage = currentPage;
                if (searchBtn != null && searchBtn == "Search")
                {
                    studentViewModel.StudentFilter.CurrentPage = 1;
                }
                studentViewModel.StudentFilter.MaxRows = maxRows;

                studentViewModel.Students = await _studentService.GetStudents(studentViewModel.StudentFilter);
                return View(studentViewModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                StudentViewModel studentVM = new StudentViewModel();
                studentVM.Student = new StudentModel();
                studentVM.Classes = await _classService.GetAllClasses();
                return View(studentVM);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel studentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _studentService.CreateStudent(studentVM.Student);
                    if (!result)
                    {
                        TempData["ErrorMsg"] = "Failed to add student";
                        return RedirectToAction("Create");
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    studentVM.StudentFilter = new StudentFilter();
                    studentVM.Students = await _studentService.GetStudents(studentVM.StudentFilter);
                    return View(studentVM);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Authorize("RequireAdmin")]
        public async Task<IActionResult> Delete(Guid studentId, int currentPage = 1)
        {
            try
            {
                bool succeded = await _studentService.DeleteStudent(studentId);
                if (!succeded) ViewBag.Error = "Something wrong";

                return RedirectToAction("Index", new { currentPage = currentPage });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
