CREATE TABLE [dbo].[Users] (
    [id]      INT            IDENTITY (1, 1) NOT NULL,
    [usrName] NVARCHAR (MAX) NULL,
    [pswrd]   NVARCHAR (MAX) NULL,
	[mail]    NVARCHAR (MAX) NULL,
    [ifAdmin] BIT NULL, 
    [ico] IMAGE NULL, 
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([id] ASC)
);

