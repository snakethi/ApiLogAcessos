using System.ComponentModel.DataAnnotations;


namespace LocalDBModels.Models
{
    public class Usuario
    {
        [Required]
        public int Usuarioid { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
