using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Projeto_FourTask___Avaliação_Final.Areas.Identity.Data;
using Projeto_FourTask___Avaliação_Final.Models;
using Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces;

namespace Projeto_FourTask___Avaliação_Final.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IdentidadeContext _context;

        public UsuarioRepositorio(IdentidadeContext context)
        {
            _context = context;
        }

        public Usuario ObterUsuario(string id)
        {
            return _context
                .Usuarios
                .Include(x => x.Tarefas)
                .Include(x => x.Equipe)
                .ThenInclude(x => x.Tarefas)
                .Where(x => x.Id == id)
                .FirstOrDefault() ?? new Usuario();

        }

        public int DefinirEquipeUsuario(string usuarioId, int equipeId)
        {
            const string UPDATEATUALIZAREQUIPE = "UPDATE AspNetUsers SET EquipeId = @EquipeId WHERE Id = @Id";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@EquipeId", equipeId));
            parametros.Add(new SqlParameter("@Id", usuarioId));

            var linhasAfetadas = _context.Database.ExecuteSqlRaw(UPDATEATUALIZAREQUIPE, parametros);

            return linhasAfetadas;
        }
    }
}
