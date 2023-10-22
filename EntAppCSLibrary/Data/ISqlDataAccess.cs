using Dapper;
using System.Data.SqlClient;

namespace EntAppCSLibrary.Data
{
    public interface ISqlDataAccess
    {
        Task SaveDataAsync(string storedProcedure, DynamicParameters data, string connectionStringName = "Default");
        void OpenConnection(string connectionStringName = "Default");
        void CloseConnection();
        SqlConnection Connection { get; }
    }
}