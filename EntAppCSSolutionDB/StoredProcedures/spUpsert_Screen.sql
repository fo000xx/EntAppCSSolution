CREATE PROCEDURE [dbo].[spUpsert_Screen]
	@ScreenId int output,
	@Title nvarchar(50),
	@ScreenType nvarchar(50),
	@Rating int,
	@IsWatched bit

AS
begin

	if exists (select 1 from Screen where CONCAT(Title, ScreenType) = CONCAT(@Title, @ScreenType))
	begin
		update Screen set
			Title = @Title,
			ScreenType = @ScreenType,
			Rating = @Rating,
			IsWatched = @IsWatched
		where CONCAT(Title, ScreenType) = CONCAT(@Title, @ScreenType);
		select @ScreenId = Id from Screen where CONCAT(Title, ScreenType) = CONCAT(@Title, @ScreenType);
	end
	else
	begin
		insert into Screen (Title, ScreenType, Rating, IsWatched)
		values (@Title, @ScreenType, @Rating, @IsWatched);
		select @ScreenId = SCOPE_IDENTITY();
	end

end