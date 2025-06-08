using Articles.Dal.DbContext;
using Articles.Dal.Options;
using Articles.Dal.Repositories;
using Articles.Domain.Articles.Repositories;
using Articles.Domain.Sections.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Articles.Dal;

public static class ForAppBuilder
{
    public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(ConnectionStringNames.Default)));

        services
            .Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));
        
        services
            .AddScoped<IArticleRepository, ArticleRepository>()
            .AddScoped<ISectionRepository, SectionRepository>();

        return services;
    }

    public static void MigrateDatabase(this IServiceProvider services, IConfiguration configuration)
    {
        using var scope = services.CreateScope();
        
        var options = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>();
        if (options.Value.MigrateOnStartup)
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }
    }
}