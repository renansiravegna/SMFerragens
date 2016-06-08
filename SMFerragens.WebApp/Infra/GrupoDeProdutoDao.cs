using SMFerragens.WebApp.Models;
using System.Collections.Generic;

namespace SMFerragens.WebApp.Infra
{
    public class GrupoDeProdutoDao
    {
        private readonly dynamic _bancoDeDados;

        public GrupoDeProdutoDao(dynamic bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public IEnumerable<GrupoDeProdutoVm> ObterTodos()
        {
            return _bancoDeDados.GrupoProduto.All();
        }
    }
}