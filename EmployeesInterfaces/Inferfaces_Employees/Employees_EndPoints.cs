using EmployeesModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesInterfaces.Inferfaces_Employees
{
    public class Employees_EndPoints : IEmployees_EndPoints
    {
        private string BaseApi = " https://dummy.restapiexample.com/api/v1";

        public List<EmployeesStatus> GetEmployeesStatuses()
        {
            List<EmployeesStatus> teste = new List<EmployeesStatus>();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync($"{BaseApi}/employees"))
                {
                    var apiResponse = response.Result.ToString();
                    return teste;// JsonConvert.DeserializeObject<List<EmployeesStatus>>(apiResponse).ToList();
                }
            }
        }

        public bool GetEmployeesTeste()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync($"{BaseApi}/employees"))
                {
                    var apiResponse = response.Result.ToString();
                }
            }

            return true;
        }
    }
}
