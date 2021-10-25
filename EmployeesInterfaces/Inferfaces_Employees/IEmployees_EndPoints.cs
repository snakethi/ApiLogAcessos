using EmployeesModels.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesInterfaces.Inferfaces_Employees
{
    public interface IEmployees_EndPoints
    {
        List<EmployeesStatus> GetEmployeesStatuses();
    }
}
