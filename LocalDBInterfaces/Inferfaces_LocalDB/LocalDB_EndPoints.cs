using Dapper;
using DbConnection.Connection;
using LocalDBModels.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDBInterfaces.Inferfaces_LocalDB
{
    public class LocalDB_EndPoints : ILocalDB_EndPoints
    {
        /*Função para inserir a Conexão na Classe de Conexão do Banco , pegando do App Config do Site que requisitar*/
        public void SetaConexao()
        {
            string Servidor = Cry.Decrypt(ConfigurationSettings.AppSettings["01"].ToString());
            string User = Cry.Decrypt(ConfigurationSettings.AppSettings["03"].ToString());
            string Senha = Cry.Decrypt(ConfigurationSettings.AppSettings["04"].ToString());
            DbSession.connect = $"Data Source={Servidor};Initial Catalog=LocalDB;User Id={User};Password={Senha};";
        }
        /*Processo de Login no Banco de Foi Setado*/
        public async Task<List<Usuario>> LoginSis(string login, string senha, string ip)
        {
            try
            {
                using (var conn = DbSession.Conexao())
                {

                    var parameters = new { Login = login, Senha = senha, Ip = ip };

                    string query = "exec PRC_ACS_LoginBanco @Login, @Senha, @Ip ";
                    return (await conn.QueryAsync<Usuario>(sql: query, parameters)).ToList();

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
    }
}
