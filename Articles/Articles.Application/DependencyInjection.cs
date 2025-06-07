using Articles.Application.Articles.Services;
using Articles.Application.Articles.Services.Interfaces;
using Articles.Application.Sections.Services;
using Articles.Application.Sections.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Articles.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddTransient<IArticleService, ArticleService>()
            .AddTransient<ISectionService, SectionService>();

        return services;
    }
}