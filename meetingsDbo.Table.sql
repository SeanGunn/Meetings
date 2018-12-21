CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Username] NCHAR(10) NOT NULL, 
    [FirstName] NCHAR(10) NULL, 
    [Surname] NCHAR(10) NULL, 
    [Password] NCHAR(10) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL
)
