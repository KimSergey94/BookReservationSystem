using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Infrastructure.Data
{
    public static class DBFilesCreator
    {
        public static void CreateSqlDatabaseFiles (string filename, string connectionString)
        {
            string databaseName = Path.GetFileNameWithoutExtension(filename);
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"CREATE DATABASE {databaseName} ON PRIMARY (NAME={databaseName}, FILENAME='{filename}')";
                    command.ExecuteNonQuery();

                    command.CommandText = $"EXEC sp_detach_db '{databaseName}', 'true'";
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
