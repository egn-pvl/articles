namespace Core.BaseTypes;

/// <summary>
/// Базовый класс для сущностей приложения
/// </summary>
public abstract class Entity<TId> where TId : struct
{
    /// <summary>
    /// ID сущности
    /// </summary>
    public TId Id { get; protected set; }
}