using Dapper;
using DbConnection.Connection;
using LocalDBModels.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LocalDBInterfaces.Interfaces_Usuario
{
    public class Usuario_EndPoints : IUsuario_EndPoints
    {
        /*Pega todos os Usuarios Cadastrado*/
        public async Task<IEnumerable<Usuario>> GetAllUser()
        {
            try
            {
                using (var conn = DbSession.Conexao())
                {
                    string query = "Select * from Usuario";
                    return (await conn.QueryAsync<Usuario>(sql: query)).ToList();
                }
            }
            catch
            {
                throw;
            }
        }
        /*Pega o Usuario por Login*/
        public async Task<IEnumerable<Usuario>> GetUserbyLogin(string Login)
        {
            try
            {
                using (var conn = DbSession.Conexao())
                {
                    var parameters = new { Login = Login };
                    string query = "Select * from Usuario where Login = @Login ";
                    return (await conn.QueryAsync<Usuario>(sql: query, parameters)).ToList();
                }
            }
            catch
            {
                throw;
            }
        }
        /*Verifica a Existencia do Login no Banco*/
        public bool GetUserbyLoginBool(string Login, int ID = 0)
        {
            try
            {
                using (var conn = DbSession.Conexao())
                {

                    var parameters = new { Login = Login };
                    string query = "Select * from Usuario where Login = @Login ";

                    var achou = (conn.Query<Usuario>(sql: query, parameters)).ToList();

                    if (achou.Count == 0)
                    {
                        /*Não Achou*/
                        return false;
                    }
                    else
                    {
                        if(ID != 0)
                        {
                            if(achou[0].Usuarioid != ID)
                            {
                                /*Existe Login ja Cadastrado Com outro ID*/
                                return true;
                            }
                            else
                            {
                                /*Não Achou*/
                                return false;
                            }
                        }
                        else
                        {
                            /*Existe Login ja Cadastrado*/
                            return true;
                        }
                    }

                }
            }
            catch
            {
                throw;
            }
        }
        /*Pega o Usuario por Nome*/
        public async Task<IEnumerable<Usuario>> GetUserbyNome(string Nome)
        {
            try
            {
                using (var conn = DbSession.Conexao())
                {

                    var parameters = new { Nome = Nome };
                    string query = "Select * from Usuario where Nome = @Nome ";
                    return (await conn.QueryAsync<Usuario>(sql: query, parameters)).ToList();

                }

            }
            catch
            {
                throw;
            }
        }
        /*Processo de Insert do Usuario novo no Banco*/
        public void CreateUser(Usuario novoUsuario)
        {
            try
            {

                using (var conn = DbSession.Conexao())
                {
                    conn.Execute("PRC_ADD_Usuario", novoUsuario, commandType: CommandType.StoredProcedure);
                }

            }
            catch
            {
                throw;
            }


        }
        /*Processo de Update do Usuario no Banco*/
        public void UpdateUser(Usuario updateUsuario)
        {
            try
            {

                using (var conn = DbSession.Conexao())
                {
                    conn.Execute("PRC_UPD_Usuario", updateUsuario, commandType: CommandType.StoredProcedure);
                }

            }
            catch
            {
                throw;
            }
        }
        /*Processo de Delete do Usuario no Banco*/
        public void DeleteUser(int id)
        {
            try
            {
                using (var conn = DbSession.Conexao())
                {

                    var parameters = new { id = id };
                    string query = "Delete from Usuario where UsuarioId = @id ";
                    conn.Execute(sql: query, parameters);
                }

            }
            catch
            {
                throw;
            }


        }
        /*Processo para Verificar Padrão da Senha se o mesmo não for feito pelo Site*/
        public bool VerificaSenhaUsuario(string senha)
        {
            bool senhavalida = true;

            try
            {
                senha = Cry.Decrypt(senha);

                if (senha.Length < 10)
                {
                    senhavalida = false;
                }

                Regex rg = new Regex(@"[A-Z]");

                if (!rg.IsMatch(senha))
                {
                    senhavalida = false;
                }

                rg = new Regex(@"[a-z]");

                if (!rg.IsMatch(senha))
                {
                    senhavalida = false;
                }

                rg = new Regex(@"[ ]");

                if (rg.IsMatch(senha))
                {
                    senhavalida = false;
                }

                rg = new Regex(@"[0-9]");

                if (!rg.IsMatch(senha))
                {
                    senhavalida = false;
                }

                rg = new Regex(@"[!@#$%^&*()-+]");

                if (!rg.IsMatch(senha))
                {
                    senhavalida = false;
                }

                for (int i = 0; i < senha.Length; i++)
                {
                    string letra = senha.Substring(i, 1);
                    int quantidade = senha.Count(s => s.ToString() == letra);
                    if (quantidade > 1)
                    {
                        senhavalida = false;
                        i = senha.Length;
                    }
                }
            }
            catch
            {

            }

            return senhavalida;
        }
    }
}
