namespace Articles.Dal.Options;

public class DatabaseOptions
{
    public const string SectionName = "Database";
    
    /// <summary>
    /// Применить миграции при старте приложения
    /// </summary>
    public bool MigrateOnStartup { get; init; }
}