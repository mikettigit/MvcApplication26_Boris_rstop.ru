using MvcApplication20.Helpers;
using MvcApplication20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication26_Boris.Controllers
{
    public class HomeController : ControllerWrapper
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            string xml = Dm.GetListXml("projects", null);
            List<Post> posts = Dm.ParseList(xml).Take(3).ToList();
            ViewData["Projects"] = posts;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SendMessage(FormCollection collection)
        {
            JsonMessage jm = new JsonMessage();

            try
            {
                string body = "";
                foreach (string element in collection)
                {
                    switch (element)
                    {
                        case "name": body += "Имя: " + collection[element] + "\n"; break;
                        case "phone": body += "Телефон: " + collection[element] + "\n"; break;
                        case "message": body += "\n" + collection[element] + "\n"; break;
                    }
                }

                string subject = collection["subject"];

                MailSender.Send(subject, body);

                jm.Result = true;
                jm.Message = "Мы получили Ваш запрос и скоро свяжемся с Вами...";
            }
            catch (Exception e)
            {
                jm.Result = true;
                jm.Message = "Во время отправки произошла ошибка - " + e.ToString();
            }

            return Json(jm);
        }

    }
}
