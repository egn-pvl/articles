using Articles.Dal.Repositories;
using Articles.Domain.Articles.Repositories;
using Articles.Domain.Sections.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Articles.Dal;

public static class DependencyInjection
{
    public static IServiceCollection AddDal(this IServiceCollection services)
    {
        services
            .AddTransient<IArticleRepository, ArticleRepository>()
            .AddTransient<ISectionRepository, SectionRepository>();

        return services;
    }
}