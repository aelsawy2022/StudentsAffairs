using StudentsAffairs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAffairs.Core.IServices
{
    public interface IClassService
    {
        Task<List<ClassModel>> GetAllClasses();
    }
}
