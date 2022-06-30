using Microsoft.EntityFrameworkCore;
using Projeto_FourTask___Avaliação_Final.Areas.Identity.Data;
using Projeto_FourTask___Avaliação_Final.Models;
using Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces;

namespace Projeto_FourTask___Avaliação_Final.Repositorio
{
    public class EquipeRepositorio : IEquipeRepositorio
    {
        private readonly IdentidadeContext _context;

        public EquipeRepositorio(IdentidadeContext context)
        {
            _context = context;
        }

        public int Adicionar(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
            _context.SaveChanges();

            return equipe.EquipeId;
        }

        public Equipe ObterEquipe(int id)
        {
            return _context
                .Equipes
                .Include(x => x.Tarefas)
                .Where(x => x.EquipeId == id)
                .FirstOrDefault() ?? new Equipe();
        }

        public List<Equipe> ListarEquipes()
        {
            return _context.Equipes.ToList();
        }

        public void Salvar(Equipe equipe)
        {
            _context.Equipes.Update(equipe);
            _context.SaveChanges(true);
        }
    }
}
