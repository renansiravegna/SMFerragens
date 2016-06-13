using System.ComponentModel;

namespace SMFerragens.WebApp.Models
{
    public enum FormaDeVenda
    {
        [Description("Metro")]
        Metro = 1,

        [Description("3 metros")]
        TresMetros = 2,

        [Description("Unidade")]
        Unidade = 3,

        [Description("Cinquenta")]
        Cinquenta = 4,

        [Description("Cento")]
        Cento = 5,

        [Description("Quilo")]
        Quilo = 6,
    }
}