using SMFerragens.WebApp.Infra;
using SMFerragens.WebApp.Models;
using System.Collections.Generic;

namespace SMFerragens.WebApp.Services
{
    public class ConsultaDeProdutosPorGrupo
    {
        private readonly GrupoDeProdutoDao _grupoDeProdutoDao;
        private readonly ProdutoDao _produtoDao;

        public ConsultaDeProdutosPorGrupo(GrupoDeProdutoDao grupoDeProdutoDao, ProdutoDao produtoDao)
        {
            _grupoDeProdutoDao = grupoDeProdutoDao;
            _produtoDao = produtoDao;
        }

        public IEnumerable<GrupoComProdutosVm> Consultar()
        {
            var gruposComProdutos = new List<GrupoComProdutosVm>();
            var gruposDeProduto = _grupoDeProdutoDao.ObterTodos();

            foreach (var grupoDeProduto in gruposDeProduto)
            {
                var produtosDoGrupo = _produtoDao.ObterPorGrupoDeProduto(grupoDeProduto);
                var grupoComProdutos = new GrupoComProdutosVm
                {
                    Grupo = grupoDeProduto,
                    Produtos = produtosDoGrupo
                };

                gruposComProdutos.Add(grupoComProdutos);
            }

            return gruposComProdutos;
        }
    }
}