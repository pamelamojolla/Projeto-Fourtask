using Microsoft.AspNetCore.Identity;

namespace Projeto_FourTask___Avaliação_Final.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime? DataNascimento { get; set; }

        public Equipe? Equipe { get; set; }

        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
