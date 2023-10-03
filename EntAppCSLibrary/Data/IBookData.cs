using EntAppCSLibrary.Models;

namespace EntAppCSLibrary.Data
{
    public interface IBookData
    {
        Task InsertBookAsync(BookModel data);
    }
}