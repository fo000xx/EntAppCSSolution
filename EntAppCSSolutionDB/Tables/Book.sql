CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
	[Title] varchar(50) NOT NULL, 
    [Author] VARCHAR(50) NOT NULL, 
    [Series] VARCHAR(50) NOT NULL, 
    [Genre] VARCHAR(50) NOT NULL,
    [Rating] INT NOT NULL, 
    [isRead] BIT NOT NULL,

)
