using MvcApplication20.Helpers;
using MvcApplication20.Models;
using System.Web.Mvc;

namespace MvcApplication26_Boris.Controllers
{
    public class ControllerWrapper : Controller
    {
        //
        // GET: /ControllerWrapper/

        protected DataModel Dm
        {
            get
            {
                DataModel result = null;

                SessionManager sm = new SessionManager();

                object dm = sm.Get("Dm");
                if (dm != null)
                {
                    result = dm as DataModel;
                }
                else
                {
                    result = new DataModel();
                    sm.Set("Dm", result);
                }

                return result;
            }
        }


    }
}
