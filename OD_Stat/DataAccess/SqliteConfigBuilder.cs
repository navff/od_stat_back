using Microsoft.Data.Sqlite;

namespace OD_Stat.DataAccess
{
    public static class SqliteConfigBuilder
    {
        public static SqliteConnection GetConnection()
        {
            var builder = new SqliteConnectionStringBuilder()
            {
                DataSource = "test",
                Mode = SqliteOpenMode.Memory,
                Cache = SqliteCacheMode.Shared
            };
            var connection = new SqliteConnection(builder.ConnectionString);
            connection.Open();
            connection.EnableExtensions(true);
            return connection;
        }
    }
}