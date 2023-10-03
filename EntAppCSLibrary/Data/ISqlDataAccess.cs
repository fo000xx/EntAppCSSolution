using Dapper;

namespace EntAppCSLibrary.Data
{
    public interface ISqlDataAccess
    {
        Task SaveData(string storedProcedure, DynamicParameters data, string connectionStringName = "Default");
    }
}