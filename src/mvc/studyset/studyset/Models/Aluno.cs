using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studyset.Models
{
    [Table("Usuarios")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o tempo disponível para estudos")]
        public int TempoEstudo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a meta de estudos")]
        public int MetaEstudo { get; set; }
    }
}
