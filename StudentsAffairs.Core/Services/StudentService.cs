using AutoMapper;
using StudentsAffairs.Core.IServices;
using StudentsAffairs.Models;
using StudentsAffairs.Persistance.Data.Entities;
using StudentsAffairs.Persistance.Repositories.ClassRepo;
using StudentsAffairs.Persistance.Repositories.StudentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAffairs.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public StudentService(
            IStudentRepository studentRepository, 
            IClassRepository classRepository, 
            IImageService imageService,
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _imageService = imageService;
            _mapper = mapper;
        }

        public async Task<bool> CreateStudent(StudentModel model)
        {
            Student student = _mapper.Map<Student>(model);
            student.StudentGuid = Guid.NewGuid();
            student.Class = await _classRepository.GetByIDAsync(student.ClassId);

            if (model.ImageFile != null)
            {
                bool isDeleted = await _imageService.DeleteCurrentImageIfExists(student.Photo);
                if(isDeleted) student.Photo = await _imageService.UploadImage(model.ImageFile);
            }

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveAsync();

            return true;
        }

        public async Task<bool> DeleteStudent(Guid id)
        {
            Student student = await _studentRepository.GetFirstAsync(s => s.StudentGuid == id);

            if (student == null) return false;

            await _studentRepository.DeleteAsync(student);
            await _studentRepository.SaveAsync();

            return true;
        }

        public async Task<List<StudentModel>> GetAllStudents()
        {
            List<Student> students = await _studentRepository.GetAllAsync() as List<Student>;
            return _mapper.Map<List<StudentModel>>(students);
        }

        public async Task<List<StudentModel>> GetStudents(StudentFilter filter)
        {
            Expression<Func<Student, bool>> _Expression = null;

            if (filter != null)
            {
                _Expression =
                (
                    x => (!string.IsNullOrEmpty(filter.ClassName) ? x.Class.Name.ToLower().Contains(filter.ClassName.ToLower()) : true)
                );
            }

            List<Student> students = await _studentRepository.GetAsync(_Expression, null, "Class", filter.MaxRows, (filter.CurrentPage - 1) * filter.MaxRows) as List<Student>;

            int count = await _studentRepository.GetCountAsync(_Expression);

            double pageCount = (double)((decimal)count / Convert.ToDecimal(filter.MaxRows));
            filter.PageCount = (int)Math.Ceiling(pageCount);
            filter.CurrentPage = filter.CurrentPage;

            return _mapper.Map<List<StudentModel>>(students);
        }
    }
}