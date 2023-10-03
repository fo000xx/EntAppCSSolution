CREATE TABLE [dbo].[Screen]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Title] VARCHAR(50) NOT NULL, 
    [ScreenType] VARCHAR(50) NOT NULL,
    [Rating] INT NOT NULL, 
    [isWatched] BIT NOT NULL
)
