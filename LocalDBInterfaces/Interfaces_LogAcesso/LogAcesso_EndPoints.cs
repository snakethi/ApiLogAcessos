using Dapper;
using DbConnection.Connection;
using LocalDBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDBInterfaces.Interfaces_LogAcesso
{
    public class LogAcesso_EndPoints : ILogAcesso_EndPoints
    {
        /*Pega todos os Acesso do Usuario ao Site por Hora do Dia*/
        public async Task<IEnumerable<UserAcessoHorarios>> GetAllAcessUserbyTime(int id)
        {
            try
            {
                using (var conn = DbSession.Conexao())
                {
                    var parameters = new { id = id };
                    string query = "exec PRC_GET_AcessosPorHoraPorUsuario @Id ";
                    return (await conn.QueryAsync<UserAcessoHorarios>(sql: query, parameters)).ToList();
                }
            }
            catch
            {
                throw;
            }
        }
        /*Pega todos os Acesso do Usario ao Site*/
        public async Task<IEnumerable<UserLogAcesso>> GetAllAcessUserDados(int id)
        {
            try
            {
                using (var conn = DbSession.Conexao())
                {
                    var parameters = new { id = id };
                    string query = "exec PRC_GET_AcessosPorUsuario @Id";
                    return (await conn.QueryAsync<UserLogAcesso>(sql: query, parameters)).ToList();
                }

            }
            catch
            {
                throw;
            }
        }
    }
}
