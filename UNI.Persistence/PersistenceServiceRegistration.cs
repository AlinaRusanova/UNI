using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UNI.Domain;
using UNI.Domain.Contracts;
using UNI.Domain.Repositories;
using UNI.Persistence.Services;
using UNI.Persistence.Models;

namespace UNI.Persistence
{
    public static class PersistenceServiceRegistration
    {
        private const string ConnectionString = "UniDbConnectionStrings";

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                connectionString = ConnectionString;


            services.AddDbContext<UniDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString(connectionString), x => x.MigrationsAssembly("UNI.Persistence"));
            });

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourse_GroupRepository, Course_GroupRepository>();

            services.AddScoped<IGroupService<GroupModel>, GroupService>();
            services.AddScoped<ICourseService<CourseModel>, CourseService>();
            services.AddScoped<IStudentService<StudentModel>, StudentService>();


            return services;
        }
    }
}
