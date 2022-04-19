using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public class UsuarioCreateModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Senha { get; set; }
        [Display(Name = "Confirme sua Senha")]
        public string SenhaConfirmacao { get; set; }
        public bool Ativo { get; set; }
    }
}
