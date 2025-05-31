using Cms.Application.Interfaces;
using Cms.Application.Services;
using Cms.Domain.Repositories;
using Cms.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContentService, ContentService>();

            services.AddMemoryCache(); // IMemoryCache
            return services;
        }
    }

}