using LocalDBInterfaces.Inferfaces_LocalDB;
using Services;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApiLogAcessos.Controllers
{
    public class LocalDBController : ApiController
    {
        ILocalDB_EndPoints LEndPoints = new LocalDB_EndPoints();

        /*EndPoint de Login no Site*/
        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("LoginSis/{login},{senha},{ip}")]
        public async Task<IHttpActionResult> LoginSis(string login, string senha, string ip)
        {
            /*Grava na pasta raiz da API um Arquivo de Log de Requisições*/
            LogRequisicoesApis.GravaLogAcoes(HttpContext.Current.Request.PhysicalApplicationPath, HttpContext.Current.Request.Url.ToString(), HttpContext.Current.Request.HttpMethod.ToString());

            ip = ip.Replace("-", ".");

            try
            {
                return Ok(await LEndPoints.LoginSis(login, senha, ip));
            }
            catch
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao Logar no Sistema!");
            }
        }

    }
}
