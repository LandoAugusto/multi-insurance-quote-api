using System.ComponentModel;

namespace MultiQuoteApi.Core.Entities.Enumerators
{
    public enum DocumentTypeEnum
    {
        [Description("CPF")]
        CPF = 1,

        [Description("CNPJ")]
        CNPJ = 2,
    }
}
