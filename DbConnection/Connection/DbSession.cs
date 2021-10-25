using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnection.Connection
{
    public class DbSession
    {
        /*Cria Processo de Conexão Comum para Todas as APIS ou Sistemas*/
        public static string connect;
        public static IDbConnection Connection { get; set; }
        public static IDbConnection Conexao()
        {
            Connection = new SqlConnection(connect);
            Connection.Open();
            return Connection;
        }
        public void Dispose() => Connection?.Dispose();
    }
}
