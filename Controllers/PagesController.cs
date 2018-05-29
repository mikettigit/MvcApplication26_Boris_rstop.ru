using System.Web.Mvc;

namespace MvcApplication26_Boris.Controllers
{
    public class PagesController : ControllerWrapper
    {
        //
        // GET: /Page/

        public ActionResult Index(string param1)
        {
            string ViewFileName = "~/Views/Pages/" + param1;

            if (Request.IsAjaxRequest())
            {
                return PartialView(ViewFileName, Dm);
            }
            else
            {
                return View(ViewFileName, Dm);
            }
        }

    }
}
