using System;
using System.ComponentModel.DataAnnotations;

namespace LocalDBModels.Models
{
    public class LogAcesso
    {
        [Required]
        public int logAcessoId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public DateTime DataHoraAcesso { get; set; }
        [Required]
        public string EnderecoIp { get; set; }
    }
}
