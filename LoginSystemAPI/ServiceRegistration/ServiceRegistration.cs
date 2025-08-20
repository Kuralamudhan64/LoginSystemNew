using LoginSystemAPI.Repository;
using LoginSystemAPI.Service;


namespace LoginSystemAPI.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void RegisterApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<LoginService>();
            services.AddScoped<LoginRepository>();
        }
    }
}
