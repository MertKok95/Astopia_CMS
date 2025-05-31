using Cms.Application.Interfaces;
using Cms.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cms.Application.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IVariantSelector, StatefulVariantSelector>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContentService, ContentService>();
        }
    }
}