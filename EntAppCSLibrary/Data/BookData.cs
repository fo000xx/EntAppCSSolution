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

            _sql.OpenConnection();
            await _sql.SaveDataAsync("dbo.spUpsert_Book", p);

            int bookId = p.Get<int>("@BookId");
            _sql.CloseConnection();
        }
        
        public SearchModel GetBooks(SearchModel data)
        {
            //can use QueryFirstOrDefault with a storedprocedure and dynamicparameters.
            DynamicParameters p = new();
            p.Add("@BookId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("@Title", data.Title);
            p.Add("@Author", data.Author);
            p.Add("@Genre", data.Genre);
            p.Add("@Series", data.Series);
            p.Add("@Rating", data.Rating);
            p.Add("@IsRead", data.IsFinished);

            _sql.OpenConnection();
           
            var BookDetail = _sql.Connection.QueryFirstOrDefault<SearchModel>("dbo.spSelect_Book", p);

            _sql.CloseConnection();

            //need to handle this if BookDetail is null
            return BookDetail;
        }
    }
}
