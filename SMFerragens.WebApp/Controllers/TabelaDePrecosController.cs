using Simple.Data;
using SMFerragens.WebApp.Infra;
using SMFerragens.WebApp.Services;
using System.Web.Mvc;

namespace SMFerragens.WebApp.Controllers
{
    public class TabelaDePrecosController : Controller
    {
        public ActionResult Index()
        {
            var bancoDeDados = Database.Open();
            var grupoDeProdutoDao = new GrupoDeProdutoDao(bancoDeDados);
            var produtoDao = new ProdutoDao(bancoDeDados);
            var consultaDeProdutosPorGrupo = new ConsultaDeProdutosPorGrupo(grupoDeProdutoDao, produtoDao);

            return View(consultaDeProdutosPorGrupo.Consultar());
        }
    }
}