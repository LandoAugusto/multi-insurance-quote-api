using System.ComponentModel;

namespace MultiQuoteApi.Core.Entities.Enumerators
{
    public enum RecordStatusEnum
    {
        [Description("Ativo")]
        Active = 1,

        [Description("Inativo")]
        Inative = 2,
    }
}
