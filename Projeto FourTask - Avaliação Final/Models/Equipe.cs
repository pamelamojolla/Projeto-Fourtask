using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_FourTask___Avaliação_Final.Models
{
    public class Equipe
    {
        public Equipe()
        {
            Usuarios = new List<Usuario>();
            Tarefas = new List<Tarefa>();
        }

        public int EquipeId { get; set; }

        [Required, MaxLength(255)]
        public string Nome { get; set; }

        [Required, MaxLength(400)]
        public string Senha { get; set; }

        [Required, MaxLength(500)]
        public string Descricao { get; set; }

        [Required]
        public AreaAtuacao AreaAtuacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }

        [NotMapped]
        public string SenhaValidar { get; set; }

        public virtual ICollection<Tarefa> Tarefas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        public void AdicionarTarefa(Tarefa tarefa)
        {
            Tarefas.Add(tarefa);
        }
    }
}