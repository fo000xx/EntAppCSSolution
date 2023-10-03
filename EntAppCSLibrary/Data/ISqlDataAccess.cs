using Dapper;

namespace EntAppCSLibrary.Data
{
    public interface ISqlDataAccess
    {
        Task SaveDataAsync(string storedProcedure, DynamicParameters data, string connectionStringName = "Default");
    }
}