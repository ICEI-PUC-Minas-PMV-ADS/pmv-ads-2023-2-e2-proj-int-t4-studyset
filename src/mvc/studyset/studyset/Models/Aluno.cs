using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studyset.Models
{
    [Table("Usuarios")]
    public class Aluno
    {
        [Required(ErrorMessage = "Obrigatório informar o nome")]
        public string NomeUsuario { get; set; }

        [Key]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha")]
        public string Senha { get; set; }
  
        public int TempoEstudo { get; set; }

        public int MetaEstudo { get; set; }
    }
}
