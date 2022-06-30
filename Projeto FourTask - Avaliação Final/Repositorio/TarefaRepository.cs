using Microsoft.EntityFrameworkCore;
using Projeto_FourTask___Avaliação_Final.Areas.Identity.Data;
using Projeto_FourTask___Avaliação_Final.Models;
using Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces;

namespace Projeto_FourTask___Avaliação_Final.Repositorio
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly IdentidadeContext _context;

        public TarefaRepository(IdentidadeContext context)
        {
            _context = context;
        }

        public Tarefa ObterTarefa(int id)
        {
            return _context.Tarefas
                .Include(x => x.Equipe)
                .Where(x => x.TarefaId == id)
                .FirstOrDefault() ?? new Tarefa();
        }

        public void Remover(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            _context.Remove(tarefa);

            _context.SaveChanges();
        }

        public Tarefa Salvar(Tarefa tarefa)
        {
            if (tarefa.TarefaId > 0)
            {
                _context.Entry(tarefa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(tarefa);
            }
            else
            {
                _context.Tarefas.Add(tarefa);
            }

            _context.SaveChanges();

            return tarefa;
        }
    }
}
