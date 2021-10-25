using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAplication.Models
{
    public class DadosLogAcesso
    {
        public int LogAcessoId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string EnderecoIp { get; set; }
        public DateTime DataHoraAcesso { get; set; }

    }
}