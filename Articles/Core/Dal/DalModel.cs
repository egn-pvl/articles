namespace Core.Dal;

/// <summary>
/// Базовая Dal-модель без ID
/// </summary>
public abstract record DalModel;

/// <summary>
/// Базовая Dal-модель
/// </summary>
/// <typeparam name="TId">Тип ID</typeparam>
public abstract record DalModel<TId>
{
    /// <summary>
    /// ID записи
    /// </summary>
    public required TId Id { get; init; }
}