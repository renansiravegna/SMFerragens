using System.Web.Mvc;

namespace SMFerragens.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "TabelaDePrecos");
        }
    }
}