using StudentsAffairs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAffairs.Core.IServices
{
    public interface IStudentService
    {
        Task<List<StudentModel>> GetStudents(StudentFilter filter);
        Task<List<StudentModel>> GetAllStudents();
        Task<bool> CreateStudent(StudentModel model);
        Task<bool> DeleteStudent(Guid id);
    }
}
