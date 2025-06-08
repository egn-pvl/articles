using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Tags;

namespace Articles.Application.Articles.Commands
{
    /// <summary>
    /// Команда на изменение статьи
    /// </summary>
    public record ArticleUpdateCommand
    {
        /// <summary>
        /// ID изменяемой статьи
        /// </summary>
        public required Guid ArticleId { get; init; }
    
        /// <summary>
        /// Новое название
        /// </summary>
        /// <remarks>
        /// Если null - изменено не будет
        /// </remarks>
        public required ArticleName? Name { get; init; }
    
        /// <summary>
        /// Новый список тэгов
        /// </summary>
        /// <remarks>
        /// Если null - изменено не будет
        /// </remarks>
        public required IEnumerable<Tag>? Tags { get; init; }
    }
}