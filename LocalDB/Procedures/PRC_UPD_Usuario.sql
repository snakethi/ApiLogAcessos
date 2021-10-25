CREATE PROCEDURE [dbo].[PRC_UPD_Usuario]
	@UsuarioId   int,
	@Nome VARCHAR (100),
	@Login VARCHAR (50),
    @Senha VARCHAR (50),
    @IsAdmin BIT
AS
begin 

	Update Usuario 
	set Nome = @Nome,
		Login = @Login,
		Senha = @Senha,
		IsAdmin = @IsAdmin
	where UsuarioId = @UsuarioId

end

