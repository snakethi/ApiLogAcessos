using LocalDBModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDBInterfaces.Interfaces_LogAcesso
{
    public interface ILogAcesso_EndPoints
    {
        /*Pega todos os Acesso do Usuario ao Site por Hora do Dia*/
        Task<IEnumerable<UserAcessoHorarios>> GetAllAcessUserbyTime(int id);
        /*Pega todos os Acesso do Usario ao Site*/
        Task<IEnumerable<UserLogAcesso>> GetAllAcessUserDados(int id);
    }
}
