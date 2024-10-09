using SQLite;

namespace CarListApp.Extensions
{
    public static class AddSqliteConnectionExtension
    {
        public static IServiceCollection AddSqliteConnection(this IServiceCollection services)
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Cars.db3");

            return services.AddSingleton(sp => ActivatorUtilities.CreateInstance<SQLiteConnection>(sp, dbPath));
        }
    }
}
