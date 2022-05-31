using Oracle_query.Models;
using Oracle_query.ModelView.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oracle_query.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EMPModelView emplview = new EMPModelView();
            List<EMP> emp = emplview.GEtdb();

            return View(emp);
        }
    }
}