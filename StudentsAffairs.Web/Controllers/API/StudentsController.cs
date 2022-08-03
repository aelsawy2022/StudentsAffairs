using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAffairs.Core.IServices;
using StudentsAffairs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsAffairs.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(
            IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("", Name = "GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                List<StudentModel> students = await _studentService.GetAllStudents();
                if (students != null)
                {
                    return Ok(students);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
