using MvcApplication20.Helpers;
using MvcApplication20.Models;
using MvcApplication3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication26_Boris.Controllers
{
    public class ProjectsController : ControllerWrapper
    {
        //
        // GET: /Projects/

        [AcceptVerbs(new string[] { "Get", "Post" })]
        public ActionResult List()
        {
            string PageId = Request.Params["page"];
            string xml = Dm.GetListXml("projects", PageId);

            List<Post> posts = Dm.ParseList(xml);

            Category category = Dm.ParseCategory(xml);
            category.Name = "projects";

            if (Request.HttpMethod.ToLower() == "post")
            {
                JsonMessage jm = new JsonMessage();

                if (posts.Count > 0)
                {
                    jm.Result = true;
                    jm.Object = posts;
                }
                else
                {
                    jm.Result = false;
                }

                return Json(jm);
            }
            else
            {
                ViewData["Posts"] = posts;
                ViewData["Category"] = category;
                return View();
            }
        }

        public ActionResult Item(string param1)
        {
            Post post = Dm.GetItem(param1);

            Category category = new Category();
            category.Name = "projects";

            ViewData["Post"] = post;
            ViewData["Category"] = category;

            return View();
        }

    }
}
