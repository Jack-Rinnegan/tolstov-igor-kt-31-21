using TolstovIgorKt_31_21.Interfaces.HourlyLoadInterfaces;


namespace TolstovIgorKt_31_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHourlyLoadService, HourlyLoadService>();

            return services;
        }
    }
}
