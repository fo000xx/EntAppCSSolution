using Dapper;
using EntAppCSLibrary.Models;
using System.Data;

namespace EntAppCSLibrary.Data
{
    public class ScreenData : IScreenData
    {
        private readonly ISqlDataAccess _sql;

        public ScreenData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task InsertScreenAsync(ScreenModel data)
        {
            DynamicParameters p = new();
            p.Add("@ScreenId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Title", data.Title);
            p.Add("@ScreenType", data.ScreenType);
            p.Add("@Rating", data.Rating);
            p.Add("@IsWatched", data.IsWatched);

            await _sql.SaveDataAsync("dbo.spUpsert_Screen", p);

            int screenId = p.Get<int>("@ScreenId");
        }
    }
}
