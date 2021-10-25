CREATE TABLE [dbo].[Usuario] (
    [UsuarioId] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]      VARCHAR (100) NOT NULL,
    [Login]     VARCHAR (50)  NOT NULL,
    [Senha]     VARCHAR (50)  NOT NULL,
    [IsAdmin]   BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([UsuarioId] ASC)
);
