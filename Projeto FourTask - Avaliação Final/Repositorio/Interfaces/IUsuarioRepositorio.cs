using Projeto_FourTask___Avaliação_Final.Models;

namespace Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario ObterUsuario(string id);
        int DefinirEquipeUsuario(string usuarioId, int equipeId);
    }
}
