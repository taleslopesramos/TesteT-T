using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Senha { get; set; }
        [Display(Name="Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}