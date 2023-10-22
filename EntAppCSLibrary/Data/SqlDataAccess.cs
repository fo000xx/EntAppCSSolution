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

        public SqlConnection Connection { get; private set; }

        public void OpenConnection(string connectionStringName = "Default")
        {
            Connection = new SqlConnection(_config.GetConnectionString(connectionStringName));
            Connection.Open();
        }

        public void CloseConnection()
        {
            Connection.Close();
        }

        public async Task SaveDataAsync(string storedProcedure,
                             DynamicParameters data,
                             string connectionStringName = "Default")
        {
            if (Connection == null || Connection.State != System.Data.ConnectionState.Open)
            {
                throw new InvalidOperationException("Connection is not open. Call OpenConnection()");
            }
            
            //using var connection = new SqlConnection(_config.GetConnectionString(connectionStringName));

            await Connection.ExecuteAsync(storedProcedure,
                                            data,
                                            commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
