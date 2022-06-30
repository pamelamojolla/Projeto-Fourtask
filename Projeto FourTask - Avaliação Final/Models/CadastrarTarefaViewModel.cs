using System.ComponentModel.DataAnnotations;

namespace Projeto_FourTask___Avaliação_Final.Models
{
    public class CadastrarTarefaViewModel
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime DataLimite { get; set; }

        public List<Equipe> Equipes { get; set; }

        [Required]
        public string EquipeId { get; set; }

        public string MensagemDeErro { get; set; }

        public Tarefa MapearTarefa()
        {
            return new Tarefa()
            {
                Descricao = Descricao,
                Titulo = Titulo,
                DataLimite = DataLimite,
                DataCriacao = DateTime.Now,
            };
        }
    }
}
