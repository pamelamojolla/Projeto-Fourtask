using Projeto_FourTask___Avaliação_Final.Models;

namespace Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces
{
    public interface IEquipeRepositorio
    {
        int Adicionar(Equipe equipe);
        List<Equipe> ListarEquipes();
        void Salvar(Equipe equipe);
        Equipe ObterEquipe(int id);
    }
}
