using Articles.Domain.Tags.ValueObjects;

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
        public required string Name { get; init; }
    
        /// <summary>
        /// Список тэгов
        /// </summary>
        public required Tag[] Tags { get; init; }
    }
}