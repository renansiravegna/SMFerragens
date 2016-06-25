using System;
using System.Runtime.CompilerServices;
using Simple.Data;
using SMFerragens.WebApp.Infra;
using SMFerragens.WebApp.Services;
using System.Web.Mvc;
using SMFerragens.WebApp.Models;

namespace SMFerragens.WebApp.Controllers
{
    public class TabelaDePrecosController : Controller
    {
        public ActionResult Index()
        {
            var bancoDeDados = Database.OpenNamedConnection("SMFerragens");
            var grupoDeProdutoDao = new GrupoDeProdutoDao(bancoDeDados);
            var produtoDao = new ProdutoDao(bancoDeDados);
            var consultaDeProdutosPorGrupo = new ConsultaDeProdutosPorGrupo(grupoDeProdutoDao, produtoDao);

            return View(consultaDeProdutosPorGrupo.Consultar());
        }

        [HttpPost]
        public void Atualizar(int codPro, FormaDeVenda formaDeVenda, decimal novoValor)
        {
            var bancoDeDados = Database.OpenNamedConnection("SMFerragens");
            var produtoDao = new ProdutoDao(bancoDeDados);
            var produto = produtoDao.ObterPorCodPro(codPro);

            produto.AlterarPreco(formaDeVenda, novoValor);
            produtoDao.AtualizarPrecos(produto);
        }
    }
}