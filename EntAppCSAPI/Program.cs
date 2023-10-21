using EntAppCSLibrary.Data;
using EntAppCSLibrary.Models;

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

app.MapPost("/book", async (IBookData db, BookModel data) =>
{
    await db.InsertBookAsync(data);
});

app.MapPost("/game", async (IGameData db, GameModel data) =>
{
    await db.InsertGameAsync(data);
});

app.MapPost("/screen", async (IScreenData db, ScreenModel data) =>
{
    await db.InsertScreenAsync(data);
});

app.Run();
