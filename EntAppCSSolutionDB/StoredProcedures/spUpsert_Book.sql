CREATE PROCEDURE [dbo].[spUpsert_Book]
	@BookId int output,
	@Title nvarchar(50),
	@Author nvarchar(50),
	@Series nvarchar(50),
	@Genre nvarchar(50),
	@Rating int,
	@isRead bit

AS
begin

	if exists (select 1 from Book where CONCAT(Title, Author) = CONCAT(@Title, @Author))
	begin
		update Book set
			Title = @Title,
			Author = @Author,
			Series = @Series,
			Genre = @Genre,
			Rating = @Rating,
			isRead = @isRead
		where CONCAT(Title, Author) = CONCAT(@Title, @Author);
		select @BookId = Id from Book where CONCAT(Title, Author) = CONCAT(@Title, @Author);
	end
	else
	begin
		insert into Book (Title, Author, Series, Genre, Rating, isRead)
		values (@Title, @Author, @Series, @Genre, @Rating, @isRead);
		select @BookId = SCOPE_IDENTITY();
	end

end