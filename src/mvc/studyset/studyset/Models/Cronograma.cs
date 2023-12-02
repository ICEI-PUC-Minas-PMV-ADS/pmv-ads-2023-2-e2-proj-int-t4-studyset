using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studyset.Models
{
    [Table("Cronogramas")]
    public class Cronograma
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o conteúdo de estudo")]
        [Display(Name = "Conteúdo")]
        public string ConteudoEstudo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o dia")]
        [Display(Name = "Dia")]
        public DiaEstudo DiaEstudo { get; set; }

        [Display(Name = "Aluno")]
        public string AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }

        [NotMapped] // Não mapeada no banco de dados
        public int TempoEstudoPadrao => 1; // Valor padrão de 1 hora
    }

    public enum DiaEstudo
    {
        Domingo,
        Segunda,
        Terca,
        Quarta,
        Quinta,
        Sexta,
        Sabado
    }
}
