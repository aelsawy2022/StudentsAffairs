using AutoMapper;
using StudentsAffairs.Core.IServices;
using StudentsAffairs.Models;
using StudentsAffairs.Persistance.Data.Entities;
using StudentsAffairs.Persistance.Repositories.ClassRepo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAffairs.Core.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassService(
            IClassRepository classRepository,
            IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassModel>> GetAllClasses()
        {
            List<Class> classes = await _classRepository.GetAllAsync() as List<Class>;
            return _mapper.Map<List<ClassModel>>(classes);
        }
    }
}
