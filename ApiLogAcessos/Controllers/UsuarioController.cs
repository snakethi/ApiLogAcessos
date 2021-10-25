using LocalDBInterfaces.Interfaces_Usuario;
using LocalDBModels.Models;
using Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApiLogAcessos.Controllers
{
    public class UsuarioController : ApiController
    {
        IUsuario_EndPoints UEndPoints = new Usuario_EndPoints();

        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("GetAllUser")]
        public async Task<IHttpActionResult> GetAllUser()
        {
            /*Pegar Todos os Usuario Cadastrados*/
            try
            {
                /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
                LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());

                return Ok(await UEndPoints.GetAllUser());
            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao Solititar todos os Usuários!");
            }
            
        }

        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("GetUserbyLogin/{Login}")]
        public async Task<IHttpActionResult> GetUserbyLogin(string Login)
        {
            /*Pegar o Usuario por Login*/
            try
            {
                /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
                LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());

                return Ok(await UEndPoints.GetUserbyLogin(Login));
            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao Solititar Usuários por Login!");
            }
        }

        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("GetUserbyNome/{Nome}")]
        public async Task<IHttpActionResult> GetUserbyNome(string Nome)
        {
            /*Pegar Usuario por Nome*/
            try
            {
                /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
                LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());

                return Ok(await UEndPoints.GetUserbyNome(Nome));
            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao Solititar Usuários por Nome!");
            }

            
        }

        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser(Usuario usuario)
        {
            /*Cadastro de Nome Usuario*/
            try
            {
                /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
                LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());

                if (UEndPoints.VerificaSenhaUsuario(usuario.Senha))
                {
                    usuario.Nome = usuario.Nome.ToUpper();
                    usuario.Login = usuario.Login.ToUpper();

                    if (!UEndPoints.GetUserbyLoginBool(usuario.Login))
                    {
                        UEndPoints.CreateUser(usuario);
                    }
                    else
                    {
                        return Content(HttpStatusCode.Ambiguous, $"Usuario já existe para o Login = {usuario.Login}");
                    }

                    return Content(HttpStatusCode.OK, $"Usuario {usuario.Login} criado com sucesso!");
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Senha não tem os Requisitos minimos de Segurança!");
                }
                 
            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao Criar Usuario!");
            }   

        }

        [HttpPut]
        [Route("UpdUser")]
        public IHttpActionResult UpdUser(Usuario usuario)
        {
            /*Update de Usuario*/
            try
            {
                /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
                LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());


                if (UEndPoints.VerificaSenhaUsuario(usuario.Senha))
                {
                    usuario.Nome = usuario.Nome.ToUpper();
                    usuario.Login = usuario.Login.ToUpper();

                    if (!UEndPoints.GetUserbyLoginBool(usuario.Login , usuario.Usuarioid))
                    {
                        UEndPoints.UpdateUser(usuario);
                        return Content(HttpStatusCode.OK, $"Usuario {usuario.Login} atualizado com Sucesso!");
                    }
                    else
                    {
                        return Content(HttpStatusCode.Ambiguous, $"Usuario já existe para o Login = {usuario.Login}");
                    }
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "Senha não tem os Requisitos minimos de Segurança!");
                }

            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao Fazer Update no Usuario!");
            }
           

        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            /*Exclusão de Usuario*/
            try
            {
                /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
                LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());

                UEndPoints.DeleteUser(id);

                return Content(HttpStatusCode.OK, true);

            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, false);
            }

            

        }

    }

}
