CREATE PROCEDURE [dbo].[spSelect_Book]
	@Title NVARCHAR(50) = NULL,
	@Author NVARCHAR(50) = NULL,
	@Series NVARCHAR(50) = NULL,
	@Genre NVARCHAR(50) = NULL,
	@Rating INT = NULL,
	@IsRead BIT = NULL

AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @sql NVARCHAR(MAX);
	SET @sql = 'SELECT * FROM Book WHERE 1 = 1';

	IF @Title IS NOT NULL
		SET @sql = @sql + ' AND Title LIKE @Title';
	IF @Author IS NOT NULL
		SET @sql = @sql + ' AND Author LIKE @Author';
	IF @Series IS NOT NULL
		SET @sql = @sql + ' AND Series LIKE @Series';
	IF @Genre IS NOT NULL
		SET @sql = @sql + ' AND Genre LIKE @Genre';
	IF @Rating IS NOT NULL
		SET @sql = @sql + ' AND Rating = @Rating';
	IF @IsRead IS NOT NULL
		SET @sql = @sql + ' AND IsRead = @IsRead';

	EXEC sp_executesql @sql, N'@Title NVARCHAR(50), @Author NVARCHAR(50), @Series NVARCHAR(50), @Genre NVARCHAR(50), @Rating INT, @IsRead BIT', 
								@Title, @Author, @Series, @Genre, @Rating, @IsRead;
END