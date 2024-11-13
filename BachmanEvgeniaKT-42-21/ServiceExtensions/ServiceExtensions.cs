using BachmanEvgeniaKT_42_21.Interfaces.StudentsInterfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace BachmanEvgeniaKT_42_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
