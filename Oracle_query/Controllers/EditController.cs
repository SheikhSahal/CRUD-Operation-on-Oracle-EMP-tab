using Oracle_query.Models;
using Oracle_query.ModelView.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oracle_query.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index(int id)
        {
            EMPModelView empl = new EMPModelView();
            EMP employee = empl.EmployeeDetails(id);

            return View(employee);
        }

        [HttpPost]
        public ActionResult Index(EMP emp)
        {
            if (ModelState.IsValid)
            {
                EMPModelView empl = new EMPModelView();
                empl.updateemp(emp);
                
                return RedirectToAction("index", "Home");
            }
            return View();
        }
    }
}