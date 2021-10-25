CREATE PROCEDURE [dbo].[PRC_ACS_LoginBanco]
	@Login varchar(50),
	@Senha varchar(50),
	@Ip varchar(50)
	
AS
begin

  If exists(Select * from Usuario where Login = @Login and Senha = @Senha)
  begin
    
	declare @UsuarioId int = (Select UsuarioId from Usuario where Login = @Login and Senha = @Senha)

	insert into LogAcesso values (@UsuarioId, GETDATE(), @Ip)

  end

  Select * from Usuario where Login = @Login and Senha = @Senha

end

