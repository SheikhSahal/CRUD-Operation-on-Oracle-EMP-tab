using Oracle_query.ModelView.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oracle_query.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        public ActionResult Index(int id)
        {
            EMPModelView empl = new EMPModelView();
            empl.Getdelete(id);
            return RedirectToAction("index","Home");
        }
    }
}