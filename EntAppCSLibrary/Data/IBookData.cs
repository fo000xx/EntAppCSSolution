﻿using EntAppCSLibrary.Models;

namespace EntAppCSLibrary.Data
{
    public interface IBookData
    {
        Task InsertBookAsync(BookModel data);
        SearchModel GetBooks(SearchModel data);
    }
}