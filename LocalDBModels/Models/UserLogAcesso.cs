using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDBModels.Models
{
    public class UserLogAcesso
    {
        public int LogAcessoId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string EnderecoIp { get; set; }
        public DateTime DataHoraAcesso { get; set; }
    }
}
