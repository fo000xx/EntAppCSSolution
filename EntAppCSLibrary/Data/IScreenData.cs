using EntAppCSLibrary.Models;

namespace EntAppCSLibrary.Data
{
    public interface IScreenData
    {
        Task InsertScreenAsync(ScreenModel data);
    }
}