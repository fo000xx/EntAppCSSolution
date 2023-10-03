using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace EntAppCSLibrary.Data
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public Task SaveData(string storedProcedure,
                             DynamicParameters data,
                             string connectionStringName = "Default")
        {
            using var connection = new SqlConnection(_config.GetConnectionString(connectionStringName));

            return connection.ExecuteAsync(storedProcedure,
                                            data,
                                            commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
