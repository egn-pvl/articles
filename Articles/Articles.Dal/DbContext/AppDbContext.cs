using Articles.Dal.DalModels;
using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace Articles.Dal.DbContext;

/// <summary>
/// Контекст БД
/// </summary>
public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    /// <summary>
    /// Статьи
    /// </summary>
    public DbSet<ArticleDal> Articles => Set<ArticleDal>();

    /// <summary>
    /// Тэги
    /// </summary>
    public DbSet<TagDal> Tags => Set<TagDal>();

    /// <summary>
    /// Связи статей и тэгов
    /// </summary>
    public DbSet<ArticleTagDal> ArticleTags => Set<ArticleTagDal>();
    
    /// <summary>
    /// ctor
    /// </summary>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options){}

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region ArticleTagDal

        modelBuilder.Entity<ArticleTagDal>()
            .HasKey(at => new { at.ArticleId, at.TagId });

        modelBuilder.Entity<ArticleTagDal>()
            .HasOne(at => at.Article)
            .WithMany(a => a.ArticleTags)
            .HasForeignKey(at => at.ArticleId);
        
        modelBuilder.Entity<ArticleTagDal>()
            .HasOne(at => at.Tag)
            .WithMany(a => a.ArticleTags)
            .HasForeignKey(at => at.TagId);

        modelBuilder.Entity<ArticleTagDal>()
            .HasIndex(at => new { at.ArticleId, at.Order })
            .IsUnique();

        #endregion

        #region ArticleDal

        modelBuilder.Entity<ArticleDal>()
            .HasIndex(a => a.SectionId);

        modelBuilder.Entity<ArticleDal>(entity =>
        {
            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(ArticleName.MaxLength);

            entity.Property(a => a.CreatedAt)
                .IsRequired();

            entity.Property(a => a.SectionId)
                .IsRequired();
        });

        #endregion
        
        #region TagDal

        modelBuilder.Entity<TagDal>(entity =>
        {
            entity.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(Tag.MaxLength);
        });

        #endregion
    }
}