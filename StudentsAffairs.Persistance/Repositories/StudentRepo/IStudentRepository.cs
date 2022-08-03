using StudentsAffairs.Persistance.Data.Entities;
using StudentsAffairs.Persistance.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAffairs.Persistance.Repositories.StudentRepo
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
