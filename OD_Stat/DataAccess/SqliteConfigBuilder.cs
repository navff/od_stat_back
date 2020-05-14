using Microsoft.Data.Sqlite;

namespace OD_Stat.DataAccess
{
    public static class SqliteConfigBuilder
    {
        public static SqliteConnection GetConnection()
        {
            var connection = new SqliteConnection("DataSource='file::memory:?cache=shared'");
            connection.Open();
            connection.EnableExtensions(true);
            return connection;
        }
    }
}