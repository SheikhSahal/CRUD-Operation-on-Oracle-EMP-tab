using Oracle.ManagedDataAccess.Client;
using Oracle_query.Models;
using Oracle_query.ModelView.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oracle_query.Controllers
{
    public class AddEmployeeController : Controller
    {
        string oradb = "Data Source=dbtest;User ID=psl;Password=psl;";
        // GET: AddEmployee
        public ActionResult Index()
        {
            EMPModelView empl = new EMPModelView();
            EMP employee = empl.AutoGenerate();

            //////////////////Dept Number Drop Down//////////////////
            var list = new List<DeptDropDown>();

            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "Select d.deptno,d.dname From dept d";
            cmd.Connection = con;
            con.Open();

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new DeptDropDown
                {
                    Deptid = reader.GetInt16(0),
                    Dname = reader.GetString(1)
                });
            }
            var model = new DeptModellist();
            ViewBag.drop = new SelectList(list, "deptid", "dname");
            //////////////////Dept Number Drop Down//////////////////

            return View(employee);

            
        }
        [HttpPost]
        public ActionResult Index(EMP emp)
        {
            if (ModelState.IsValid)
            {
                EMPModelView empl = new EMPModelView();
                empl.AddNewEmployee(emp);

                //////////////////Dept Number Drop Down//////////////////
                var list = new List<DeptDropDown>();

                OracleConnection con = new OracleConnection(oradb);
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "Select d.deptno,d.dname From dept d";
                cmd.Connection = con;
                con.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new DeptDropDown
                    {
                        Deptid = reader.GetInt16(0),
                        Dname = reader.GetString(1)
                    });
                }
                var model = new DeptModellist();
                ViewBag.drop = new SelectList(list, "deptid", "dname");
                //////////////////Dept Number Drop Down//////////////////


                return RedirectToAction("index","Home");

            }
            return View();   
        }
    }
}