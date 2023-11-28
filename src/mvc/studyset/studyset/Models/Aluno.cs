using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace studyset.Models
{
    // Não é necessário declarar a tabela Usuarios, pois é usada a tabela padrão do Identity
    public class Aluno : IdentityUser
    {
        //Id, Email e Senha já são fornecidos automaticamente pelo IdentityUser

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        [Display(Name = "Nome")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o tempo disponível para estudos")]
        [Display(Name = "Tempo disponível de estudo")]
        public int TempoEstudo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a meta de estudos")]
        [Display(Name = "Meta de estudo")]
        public int MetaEstudo { get; set; }

        public ICollection<Evento> Agenda { get; set; }

        public ICollection<Cronograma> Cronogramas { get; set; }

        public ICollection<Sessao> Sessoes { get; set; }
    }
}
