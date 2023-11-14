using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studyset.Models
{
    [Table("Cronogramas")]
    public class Cronograma : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o conteúdo de estudo")]
        [Display(Name = "Conteúdo")]
        public string ConteudoEstudo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data")]
        [Display(Name = "Data")]
        public DateTime DataEstudo { get; set; }

        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var dbContext = validationContext.GetService(typeof(AppDbContext)) as AppDbContext;

            // Verifica se já existe um item de cronograma para o mesmo aluno na mesma data e hora
            var existingCronograma = dbContext.Cronogramas.FirstOrDefault(c => c.AlunoId == AlunoId && c.DataEstudo == DataEstudo);

            if (existingCronograma != null)
            {
                // Se já existir, retorna uma mensagem indicando o conflito
                yield return new ValidationResult("Já existe um item cadastrado nesta hora. Atualize o item existente.", new[] { "DataEstudo" });
            }
            else
            {
                // Se não existir um item de cronograma, retorna uma lista vazia indicando que a validação foi bem-sucedida
                yield break;  // Use yield break para finalizar a iteração do iterador
            }
        }
    }
}
