using Core.BaseTypes;

namespace Core.Exceptions.Common;

/// <summary>
/// Сущность не найдена
/// </summary>
public class EntityNotFoundException<TEntity, TId> : AppException
    where TEntity : Entity<TId>
    where TId : struct
{
    public EntityNotFoundException(TId id) : base($"Entity {typeof(TEntity).Name} not found by id={id}")
    {
    }
}