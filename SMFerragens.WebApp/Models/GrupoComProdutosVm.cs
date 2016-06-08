using System.Collections.Generic;

namespace SMFerragens.WebApp.Models
{
    public class GrupoComProdutosVm
    {
        public GrupoDeProdutoVm Grupo { get; set; }
        public IEnumerable<ProdutoVm> Produtos { get; set; }
    }
}