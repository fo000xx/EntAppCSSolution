using EntAppCSLibrary.Models;

namespace EntAppCSLibrary.Data
{
    public interface IGameData
    {
        Task InsertGameAsync(GameModel data);
    }
}