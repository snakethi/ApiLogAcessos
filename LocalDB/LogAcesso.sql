CREATE TABLE [dbo].[LogAcesso] (
    [LogAcessoId]    INT          IDENTITY (1, 1) NOT NULL,
    [UsuarioId]      INT          NOT NULL,
    [DataHoraAcesso] DATETIME     NOT NULL,
    [EnderecoIp]     VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([LogAcessoId] ASC),
    FOREIGN KEY ([UsuarioId]) REFERENCES [dbo].[Usuario] ([UsuarioId])
);

