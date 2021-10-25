using LocalDBInterfaces.Interfaces_LogAcesso;
using Services;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApiLogAcessos.Controllers
{
    public class LogAcessosController : ApiController
    {
        ILogAcesso_EndPoints LEndPoints = new LogAcesso_EndPoints();

       
        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("GetAllAcessUserbyTime/{id}")]
        public async Task<IHttpActionResult> GetAllAcessUserbyTime(int id)
        {
            /*Pegar todos os Acesso do Usuario por Hora*/
            try
            {
                /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
                LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());

                return Ok(await LEndPoints.GetAllAcessUserbyTime(id));
            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, false);
            }
        }

        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("GetAllAcessUserDados/{id}")]
        public async Task<IHttpActionResult> GetAllAcessUserDados(int id)
        {
            /*Pegar todos os Acesso do Usuario*/
            try
            {
                /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
                LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());

                return Ok(await LEndPoints.GetAllAcessUserDados(id));
            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, false);
            }
        }
    }
}
