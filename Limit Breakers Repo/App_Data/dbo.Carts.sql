CREATE TABLE [dbo].[Carts] (
    [CartID] INT            IDENTITY (1, 1) NOT NULL,
    [GName]  NVARCHAR (MAX) NULL,
    [genre]  NVARCHAR (MAX) NULL,
    [price]  FLOAT (53)     NOT NULL,
    [GameID] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Carts] PRIMARY KEY CLUSTERED ([CartID] ASC),
    CONSTRAINT [FK_dbo.Carts_dbo.Games_GameID] FOREIGN KEY ([GameID]) REFERENCES [dbo].[Games] ([GameID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_GameID]
    ON [dbo].[Carts]([GameID] ASC);

