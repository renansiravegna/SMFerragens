using SMFerragens.WebApp.Models;
using System.Collections.Generic;

namespace SMFerragens.WebApp.Infra
{
    public class ProdutoDao
    {
        private readonly dynamic _bancoDeDados;

        public ProdutoDao(dynamic bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public IEnumerable<ProdutoVm> ObterPorGrupoDeProduto(GrupoDeProdutoVm grupoDeProduto)
        {
            return _bancoDeDados.Produto.FindAllByCodGrupo(grupoDeProduto.CodGrupo);
        }

        public ProdutoVm ObterPorCodPro(int codPro)
        {
            return _bancoDeDados.Produto.Get(codPro);
        }

        public void AtualizarPrecos(ProdutoVm produto)
        {
            _bancoDeDados.Produto.Update(produto);
        }
    }
}