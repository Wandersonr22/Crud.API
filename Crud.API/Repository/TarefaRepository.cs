using Crud.API.Data;
using Crud.API.Repository.Interfaces;
using CrudTarefas.API.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly SistemaTarefaDBContex _dbContext;
        public TarefaRepository(SistemaTarefaDBContex sistemaTarefaDBContex)
        {
            _dbContext = sistemaTarefaDBContex;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefaModel)
        {
            await _dbContext.Tarefas.AddAsync(tarefaModel);
            await _dbContext.SaveChangesAsync();

            return tarefaModel;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefaModel, int id)
        {
            var tarefaAtualizar = await BuscarPorId(id) ?? throw new Exception("Tarefa não encontrado");

            tarefaAtualizar.Nome = tarefaModel.Nome;
            tarefaAtualizar.Descricao = tarefaModel.Descricao;
            tarefaAtualizar.Status = tarefaModel.Status;
            tarefaAtualizar.UsuarioId = tarefaModel.UsuarioId;

            _dbContext.Tarefas.Update(tarefaAtualizar);
            await _dbContext.SaveChangesAsync();

            return tarefaAtualizar;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioApagar = await BuscarPorId(id) ?? throw new Exception("Tarefa não encontrato");

            _dbContext.Tarefas.Remove(usuarioApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
