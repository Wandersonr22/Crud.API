using Crud.API.Data;
using Crud.API.Repository.Interfaces;
using CrudTarefas.API.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaTarefaDBContex _dbContext;
        public UsuarioRepository(SistemaTarefaDBContex sistemaTarefaDBContex)
        {
            _dbContext = sistemaTarefaDBContex;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            var usuarioAtualizar = await BuscarPorId(id) ?? throw new Exception("Usuario não encontrado");

            usuarioAtualizar.Nome = usuario.Nome;
            usuarioAtualizar.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioAtualizar);
            await _dbContext.SaveChangesAsync();

            return usuarioAtualizar;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioApagar = await BuscarPorId(id) ?? throw new Exception("Usuario não encontrato");

            _dbContext.Usuarios.Remove(usuarioApagar);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
