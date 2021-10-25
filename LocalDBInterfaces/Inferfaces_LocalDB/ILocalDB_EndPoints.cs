using LocalDBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDBInterfaces.Inferfaces_LocalDB
{
    public interface ILocalDB_EndPoints
    {
        /*Função para inserir a Conexão na Classe de Conexão do Banco , pegando do App Config do Site que requisitar*/
        void SetaConexao();
        /*Processo de Login no Banco de Foi Setado*/
        Task<List<Usuario>> LoginSis(string login, string senha, string ip);
    }
}
