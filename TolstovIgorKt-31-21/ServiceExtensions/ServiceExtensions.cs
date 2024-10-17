using TolstovIgorKt_31_21.Interfaces.DepartmentInterfaces;


namespace TolstovIgorKt_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }
    }
}
