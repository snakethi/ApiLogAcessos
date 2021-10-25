CREATE PROCEDURE [dbo].[PRC_ADD_Usuario]
    @UsuarioId   int,
	@Nome VARCHAR (100),
	@Login VARCHAR (50),
    @Senha VARCHAR (50),
    @IsAdmin BIT
as
begin
    Insert into Usuario values(@Nome,@Login,@Senha,@IsAdmin)
End 


