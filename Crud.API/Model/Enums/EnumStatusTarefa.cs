using System.ComponentModel;

namespace CrudTarefas.API.Models.Enums
{
    public enum EnumStatusTarefa
    {
        [Description("A fazer")]
        Afazer = 1,
        [Description("Em andamento")]
        EmAndamento,
        [Description("Concluído")]
        Concluido
    }
}
