using Dapper;
using EntAppCSLibrary.Models;
using System.Data;

namespace EntAppCSLibrary.Data
{
    public class GameData : IGameData
    {
        private readonly ISqlDataAccess _sql;

        public GameData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task InsertGameAsync(GameModel data)
        {
            DynamicParameters p = new();
            p.Add("@GameId", dbType: DbType.Int32, direction: System.Data.ParameterDirection.Output);
            p.Add("@Title", data.Title);
            p.Add("@Genre", data.Genre);
            p.Add("@GamePlatform", data.GamePlatform);
            p.Add("@Rating", data.Rating);
            p.Add("@IsMultiplayer", data.IsMultiplayer);
            p.Add("@IsPlayed", data.IsPlayed);
            p.Add("@IsOwned", data.IsOwned);

            await _sql.SaveDataAsync("dbo.spUpsert_Game", p);

            int gameId = p.Get<int>("@GameId");
        }
    }
}
