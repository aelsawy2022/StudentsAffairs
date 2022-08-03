using StudentsAffairs.Persistance.Data.Entities;
using StudentsAffairs.Persistance.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAffairs.Persistance.Repositories.ClassRepo
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
