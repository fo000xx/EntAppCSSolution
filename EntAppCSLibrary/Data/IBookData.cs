using EntAppCSLibrary.Models;

namespace EntAppCSLibrary.Data
{
    public interface IBookData
    {
        Task InsertBook(BookModel data);
    }
}