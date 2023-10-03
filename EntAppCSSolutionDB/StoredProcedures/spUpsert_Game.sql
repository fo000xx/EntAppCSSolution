CREATE PROCEDURE [dbo].[spUpsert_Game]
	@GameId int output,
	@Title nvarchar(50),
	@Genre nvarchar(50),
	@GamePlatform nvarchar(50),
	@Rating int,
	@isMultiplayer bit,
	@isPlayed bit,
	@isOwned bit

AS
begin

	if exists (select 1 from Game where Title = @Title)
	begin
		update Game set
			Title = @Title,
			Genre = @Genre,
			GamePlatform = @GamePlatform,
			Rating = @Rating,
			isMultiplayer = @isMultiplayer,
			isPlayed = @isPlayed,
			isOwned = @isOwned
		where Title = @Title;
		select @GameId = Id from Game where Title = @Title;
	end
	else
	begin
		insert into Game (Title, Genre, GamePlatform, Rating, isMultiplayer, isPlayed, isOwned)
		values (@Title, @Genre, @GamePlatform, @Rating, @isMultiplayer, @isPlayed, @isOwned);
		select @GameId = SCOPE_IDENTITY();
	end

end