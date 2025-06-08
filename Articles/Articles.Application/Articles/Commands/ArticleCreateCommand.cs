using Articles.Domain.Articles.ValueObjects;
using Articles.Domain.Tags;

namespace Articles.Application.Articles.Commands
{
    /// <summary>
    /// Команда на создание статьи
    /// </summary>
    public record ArticleCreateCommand
    {
        /// <summary>
        /// Название
        /// </summary>
        public required ArticleName Name { get; init; }
    
        /// <summary>
        /// Список тэгов
        /// </summary>
        public required IEnumerable<Tag> Tags { get; init; }
    }
}