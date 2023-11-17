using CrudTarefas.API.Models.Enums;

namespace CrudTarefas.API.Model.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public EnumStatusTarefa Status { get; set; }
        public int? UsuarioId { get; set; }

        public virtual UsuarioModel? Usuario { get; set; }
    }
}
