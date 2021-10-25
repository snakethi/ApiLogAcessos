using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiLogAcessos.Controllers
{
    public class EmployeesController : ApiController
    {
        /*Url Base da Api*/
        string BaseApi = "https://dummy.restapiexample.com/api/v1";

        [HttpGet]
        //[Route("GetAllUser/{usuario},{senha}")]
        [Route("GetEmployeesStatus")]
        public async Task<IHttpActionResult> GetEmployeesStatus()
        {
            /*Traz todos os Empregados e Depois selecionamos so os com mais de 30 anos e passamos os Campos id ,employee_name , employee_age para nosso EndPoint*/
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync($"{BaseApi}/employees"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(apiResponse);
                        var resultObject = json["data"]
                                           .Values<JObject>()
                                           .Where(n => n["employee_age"].Value<int>() > 30)
                                           .Select(n => new { id = n["id"], employee_name = n["employee_name"], employee_age = n["employee_age"] });


                        return Json(resultObject);
                    }
                }
            }
            catch 
            {
                return Content(HttpStatusCode.BadRequest, "Erro ao Solititar todos os Empregados!");
            }

        }


    }
}
