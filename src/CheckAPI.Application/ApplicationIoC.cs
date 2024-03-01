using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CheckAPI.Application
{
    public static class ApplicationIoC
    {
        public static void ResolveApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                 cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidationBehavior<,>));
        }
    }
}
