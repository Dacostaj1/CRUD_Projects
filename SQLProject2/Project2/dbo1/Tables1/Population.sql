CREATE TABLE [dbo].[Population]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LocationId] INT NOT NULL, 
    [Size] INT NOT NULL, 
    CONSTRAINT [FK_Population_Location] FOREIGN KEY ([LocationId]) REFERENCES [Population]([Id])
)
