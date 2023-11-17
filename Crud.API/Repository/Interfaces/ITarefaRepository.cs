using CrudTarefas.API.Model.Models;

namespace Crud.API.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel tarefaModel);
        Task<TarefaModel> Atualizar(TarefaModel tarefaModel, int id);
        Task<bool> Apagar(int id);
        
    }
}
