using UserService.Repository.Interfaces;
using UserService.Repository;
using UserService.Application.Interfaces;
using UserService.Application;

namespace UserService.Api
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
           services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEndUserService,EndUserService>();
        }

        public static void AddControllerUtilities(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
