using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studyset.Models
{
    [Table("Agenda")]
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o título do evento")]
        [Display(Name = "Evento")]
        public string NomeEvento { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data do evento")]
        [Display(Name = "Data do evento")]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o tipo do evento")]
        [Display(Name = "Tipo do evento")]
        public TipoEvento Tipo { get; set; }

        [Required(ErrorMessage = "Obrigatório a prioridade")]
        [Display(Name = "Prioridade do evento")]
        public PrioridadeEvento Prioridade { get; set; }

        [Display(Name = "Aluno")]
        public string AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }
    }

    public enum TipoEvento
    {
        Prova,
        Entrega,
        Apresentação,
        Reunião,
        Outro
    }

    public enum PrioridadeEvento
    {
        Baixa,
        Média,
        Alta
    }
}
