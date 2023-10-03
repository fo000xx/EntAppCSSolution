CREATE PROCEDURE [dbo].[spUpsert_Screen]
	@ScreenId int output,
	@Title nvarchar(50),
	@ScreenType nvarchar(50),
	@Rating int,
	@isWatched bit

AS
begin

	if exists (select 1 from Screen where CONCAT(Title, ScreenType) = CONCAT(@Title, @ScreenType))
	begin
		update Screen set
			Title = @Title,
			ScreenType = @ScreenType,
			Rating = @Rating,
			isWatched = @isWatched
		where CONCAT(Title, ScreenType) = CONCAT(@Title, @ScreenType);
		select @ScreenId = Id from Screen where CONCAT(Title, ScreenType) = CONCAT(@Title, @ScreenType);
	end
	else
	begin
		insert into Screen (Title, ScreenType, Rating, isWatched)
		values (@Title, @ScreenType, @Rating, @isWatched);
		select @ScreenId = SCOPE_IDENTITY();
	end

end