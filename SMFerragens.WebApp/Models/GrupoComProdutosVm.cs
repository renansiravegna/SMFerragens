using System.Collections.Generic;
using System.Linq;

namespace SMFerragens.WebApp.Models
{
    public class GrupoComProdutosVm
    {
        public GrupoDeProdutoVm Grupo { get; set; }
        public IEnumerable<ProdutoVm> Produtos { get; set; }
        public IEnumerable<FormaDeVenda> FormasDeVenda { get { return Produtos.SelectMany(p => p.FormasDeVenda).Distinct().ToList(); } }
    }
}