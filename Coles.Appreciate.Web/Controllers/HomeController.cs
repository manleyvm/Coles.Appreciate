using Coles.Appreciate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coles.Appreciate.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(int? id)
        {

            //MyModel m = new MyModel((int)RouteData.Values["id"]);

            int apprId = Int32.Parse(RouteData.Values["id"].ToString());
            AppreciateViewModel model = new Models.AppreciateViewModel(apprId);
            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        

    }

    public class MyModel
    {
        public int AppreciateId { get; set; }
        public MyModel(int AppreciateId)
        {
            this.AppreciateId = AppreciateId;
        }
    }
}