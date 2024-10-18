using TolstovIgorKt_31_21.Interfaces.DepartmentInterfaces;
using TolstovIgorKt_31_21.Interfaces.LecturerInterfaces;


namespace TolstovIgorKt_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ILecturerService, LecturerService>();

            return services;
        }
    }
}
