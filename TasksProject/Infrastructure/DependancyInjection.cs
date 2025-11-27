using Microsoft.CodeAnalysis.CSharp.Syntax;
using TasksProject._02_Repositories.Implementions;
using TasksProject._02_Repositories.Interfaces;
using TasksProject._03_Services.Implementions;
using TasksProject._03_Services.Interfaces;
using TasksProject.Repositories.Implementions;

namespace TasksProject.Infrastructure
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
           services.AddTransient<IAccountServices, AccountServices>();
           services.AddTransient<ICourseRes_Services, CourseRes_Services>();
           services.AddTransient<ICourseServices, CourseServices>();
           services.AddTransient<IInstructorServices, InstructorServices>();
           services.AddTransient<ITraineeServices, TraineeServices>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();
            services.AddTransient<IEmailServices, EmailService>();

            //------------------------------------------------

            services.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddTransient<IInstructorRepo, InstructorRepo>();
            services.AddTransient<ITraineeRepo, TraineeRepo>();
            services.AddTransient<IcourseRepo, CourseRepo>();

           
          



            return services;
        }
    }
}
