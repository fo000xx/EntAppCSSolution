using EntAppCSLibrary.Data;
using EntAppCSLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IBookData, BookData>();
builder.Services.AddSingleton<IGameData, GameData>();
builder.Services.AddSingleton<IScreenData, ScreenData>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/bookAdd", async (IBookData db, BookModel data) =>
{
    await db.InsertBookAsync(data);
});

app.MapPost("/gameAdd", async (IGameData db, GameModel data) =>
{
    await db.InsertGameAsync(data);
});

app.MapPost("/screenAdd", async (IScreenData db, ScreenModel data) =>
{
    await db.InsertScreenAsync(data);
});

//mapget for book, game and screen. Three different ones as the interfaces for each DB will need to be passed through.
//eventually refactor into one that searches based on user input of book/game/screen?
app.MapPost("/bookSearch", (IBookData db, SearchModel data) =>
{
    db.GetBooks(data);
});

app.Run();