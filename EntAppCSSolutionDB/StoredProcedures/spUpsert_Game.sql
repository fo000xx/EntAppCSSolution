CREATE PROCEDURE [dbo].[spUpsert_Game]
	@GameId int output,
	@Title nvarchar(50),
	@Genre nvarchar(50),
	@GamePlatform nvarchar(50),
	@Rating int,
	@IsMultiplayer bit,
	@IsPlayed bit,
	@IsOwned bit

AS
begin

	if exists (select 1 from Game where Title = @Title)
	begin
		update Game set
			Title = @Title,
			Genre = @Genre,
			GamePlatform = @GamePlatform,
			Rating = @Rating,
			IsMultiplayer = @IsMultiplayer,
			IsPlayed = @IsPlayed,
			IsOwned = @IsOwned
		where Title = @Title;
		select @GameId = Id from Game where Title = @Title;
	end
	else
	begin
		insert into Game (Title, Genre, GamePlatform, Rating, IsMultiplayer, IsPlayed, IsOwned)
		values (@Title, @Genre, @GamePlatform, @Rating, @IsMultiplayer, @IsPlayed, @IsOwned);
		select @GameId = SCOPE_IDENTITY();
	end

end