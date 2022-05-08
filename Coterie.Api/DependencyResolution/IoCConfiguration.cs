namespace Coterie.Api.DependencyResolution
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Validators.ValidationBehaviour;

    public static class IoCConfiguration
    {
        /// <summary>
        /// Adds the custom services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCustomServices(this IServiceCollection services)
        {
            //Register the services
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}