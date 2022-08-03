using Microsoft.Extensions.DependencyInjection;
using StudentsAffairs.Core.IServices;
using StudentsAffairs.Core.Services;
using StudentsAffairs.Persistance.Repositories.ClassRepo;
using StudentsAffairs.Persistance.Repositories.GenericRepo;
using StudentsAffairs.Persistance.Repositories.StudentRepo;

namespace StudentsAffairs.Web.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
            services.AddScoped(typeof(IClassRepository), typeof(ClassRepository));

        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IStudentService), typeof(StudentService));
            services.AddScoped(typeof(IClassService), typeof(ClassService));
            services.AddScoped(typeof(IImageService), typeof(ImageService));

        }
    }
}
