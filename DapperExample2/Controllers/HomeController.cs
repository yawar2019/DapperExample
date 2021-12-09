using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperExample2.Models;
using Dapper;
namespace DapperExample2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

           
            var emp = ReturnData.ReturnList<EmployeeModel>("spr_getEmployeeDetails", null);

            return View(emp);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel emp)
        {
            var param = new DynamicParameters();
            param.Add("@empname", emp.EmpName);
            param.Add("@empsalary", emp.EmpSalary);
            int i = ReturnData.AddOrSave<int>("spr_InsertEmployeeDetails", param);
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            var param = new DynamicParameters();
            param.Add("@empid", id);

            var Emp = ReturnData.ReturnList<EmployeeModel>("spr_getEmployeeDetailsbyId", param).SingleOrDefault();

            return View(Emp);

        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            var param = new DynamicParameters();
            param.Add("@Empid", emp.EmpId);
            param.Add("@EmpName", emp.EmpName);
            param.Add("@EmpSalary", emp.EmpSalary);
            bool result = ReturnData.AddOrSave<bool>("spr_updateEmployeeDetails", param);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Delete(int? id)
        {
            var param = new DynamicParameters();
            param.Add("@empid", id);

            var Emp = ReturnData.ReturnList<EmployeeModel>("spr_getEmployeeDetailsbyId", param).SingleOrDefault();

            return View(Emp);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            var param = new DynamicParameters();
            param.Add("@empid", id);
           
            bool result = ReturnData.AddOrSave<bool>("spr_deleteEmployeeDetails", param);

            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}