using Projeto_FourTask___Avaliação_Final.Models;

namespace Projeto_FourTask___Avaliação_Final.Repositorio.Interfaces
{
    public interface ITarefaRepository
    {
        Tarefa ObterTarefa(int id);
        Tarefa Salvar(Tarefa tarefa);
        void Remover(Tarefa tarefa);
    }
}
