using System.ComponentModel.DataAnnotations;

namespace Projeto_FourTask___Avaliação_Final.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLimite { get; set; }

        public Usuario Usuario { get; set; }

        public Equipe Equipe { get; internal set; }

        internal void DefinirUsuario(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
