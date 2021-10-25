using LocalDBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDBInterfaces.Interfaces_Usuario
{
    public interface IUsuario_EndPoints
    {
        /*Pega todos os Usuarios Cadastrado*/
        Task<IEnumerable<Usuario>> GetAllUser();
        /*Pega o Usuario por Login*/
        Task<IEnumerable<Usuario>> GetUserbyLogin(string Login);
        /*Verifica a Existencia do Login no Banco*/
        bool GetUserbyLoginBool(string Login, int ID = 0);
        /*Pega o Usuario por Nome*/
        Task<IEnumerable<Usuario>> GetUserbyNome(string Nome);
        /*Processo de Insert do Usuario novo no Banco*/
        void CreateUser(Usuario novoUsuario);
        /*Processo de Update do Usuario no Banco*/
        void UpdateUser(Usuario updateUsuario);
        /*Processo de Delete do Usuario no Banco*/
        void DeleteUser(int id);
        /*Processo para Verificar Padrão da Senha se o mesmo não for feito pelo Site*/
        bool VerificaSenhaUsuario(string senha);
    }
}
