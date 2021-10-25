CREATE PROCEDURE [dbo].[PRC_GET_AcessosPorHoraPorUsuario]
	@Id int 
	
AS
begin

WITH nums AS
   (SELECT 0 AS value
    UNION ALL
    SELECT value + 1 AS value
    FROM nums
    WHERE nums.value <= 22)
SELECT  case value 
        when 0 then '00:00'   
		when 1 then '01:00'   
		when 2 then '02:00'   
		when 3 then '03:00'   
		when 4 then '04:00'   
		when 5 then '05:00'   
		when 6 then '06:00'   
		when 7 then '07:00'   
		when 8 then '08:00'   
		when 9 then '09:00'   
		when 10 then '10:00'   
		when 11 then '11:00'   
		when 12 then '12:00'   
		when 13 then '13:00'   
		when 14 then '14:00'   
		when 15 then '15:00'   
		when 16 then '16:00'   
		when 17 then '17:00'   
		when 18 then '18:00'   
		when 19 then '19:00'   
		when 20 then '20:00'   
		when 21 then '21:00'   
		when 22 then '22:00'   
		when 23 then '23:00' 
		end as Hora
        , Count(DataHoraAcesso) as Quantidade
FROM nums N
left join LogAcesso L on n.value = DATEPART(HOUR,L.DataHoraAcesso)
where (L.UsuarioId = @Id or @Id is null)
Group by value
Order by value


end
