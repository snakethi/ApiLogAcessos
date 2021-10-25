Create PROCEDURE [dbo].[PRC_GET_AcessosPorUsuario]
	@Id int = null
AS
begin 

select LogAcessoId, L.UsuarioId, Nome, EnderecoIp , DataHoraAcesso From LogAcesso L
join Usuario U on U.UsuarioId = L.UsuarioId
where (L.UsuarioId = @Id or @Id is null)

end


