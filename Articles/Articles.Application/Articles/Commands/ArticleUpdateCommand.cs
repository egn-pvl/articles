using Articles.Domain.Tags.ValueObjects;

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
        public required string? Name { get; init; }
    
        /// <summary>
        /// Новый список тэгов
        /// </summary>
        /// <remarks>
        /// Если null - изменено не будет
        /// </remarks>
        public required Tag[]? Tags { get; init; }
    }
}