using Dapper;
using EntAppCSLibrary.Models;
using System.Data;

namespace EntAppCSLibrary.Data
{
    public class BookData : IBookData
    {
        private readonly ISqlDataAccess _sql;

        public BookData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public async Task InsertBookAsync(BookModel data)
        {
            DynamicParameters p = new();
            p.Add("@BookId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Title", data.Title);
            p.Add("@Author", data.Author);
            p.Add("@Genre", data.Genre);
            p.Add("@Series", data.Series);
            p.Add("@Rating", data.Rating);
            p.Add("@IsRead", data.IsRead);

            await _sql.SaveDataAsync("dbo.spUpsert_Book", p);

            int bookId = p.Get<int>("@BookId");
        }
    }
}
