using Microsoft.AspNetCore.Mvc;

namespace PhotoEditorMVC.Web.Controllers
{
    public class EditPhoto : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
