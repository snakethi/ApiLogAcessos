using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiLogAcessos.Controllers
{
    public class CryController : ApiController
    {
        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("CryString/{Palavra}")]
        public string CryString(string Palavra)
        {
            /*Pegar Todos os Usuario Cadastrados*/
            try
            {
                return (Cry.Encrypt(Palavra));
            }
            catch
            {
                return ("Erro ao Criptografar!");
            }

        }

        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("sha256/{Palavra}")]
        public string sha256(string Palavra)
        {
            /*Pegar Todos os Usuario Cadastrados*/
            try
            {
                return (Cry.sha256(Palavra));
            }
            catch
            {
                return ("Erro ao Criptografar!");
            }

        }

    }
}
