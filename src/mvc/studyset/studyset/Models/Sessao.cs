using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studyset.Models
{
    [Table("Sessoes")]
    public class Sessao : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o título da sessão de estudo")]
        [Display(Name = "Título")]
        public string TituloSessao { get; set; }

        [Required(ErrorMessage = "Obrigatório a data da sessão de estudo")]
        [Display(Name = "Data")]
        [DataType(DataType.Date)] //Especifica o tipo de coluna como Data (sem hora)
        public DateTime DataSessao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o início da sessão de estudo")]
        [Display(Name = "Início da sessão")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)] // Define o formato para exibição da hora
        public DateTime InicioSessao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o fim da sessão de estudo")]
        [Display(Name = "Fim da sessão")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)] // Define o formato para exibição da hora
        public DateTime FimSessao { get; set; }

        [Column(TypeName = "Time")] //Especifica o tipo de coluna como Time
        public TimeSpan DuracaoSessao => FimSessao - InicioSessao;

        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dbContext = validationContext.GetService(typeof(AppDbContext)) as AppDbContext;

            var existingSessao = dbContext.Sessoes.FirstOrDefault(s =>
                s.AlunoId == AlunoId &&
                s.Id != Id &&
                ((InicioSessao >= s.InicioSessao && InicioSessao <= s.FimSessao) ||
                 (FimSessao >= s.InicioSessao && FimSessao <= s.FimSessao)));

            if (existingSessao != null)
            {
                var mensagemErro = "Já existe uma sessão de estudo cadastrada para neste horário.";
                yield return new ValidationResult(mensagemErro, new[] { "InicioSessao", "FimSessao" });
            }
            else
            {
                yield break;
            }
        }
    }
}
