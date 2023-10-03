CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Title] VARCHAR(50) NOT NULL, 
    [Genre] VARCHAR(50) NOT NULL, 
    [GamePlatform] VARCHAR(50) NOT NULL, 
    [Rating] BIT NOT NULL, 
    [isMultiplayer] BIT NOT NULL, 
    [isPlayed] BIT NOT NULL, 
    [isOwned] BIT NOT NULL
)
