using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperExample.Models;
using Dapper;
using System.Data.SqlClient;
using ceTe.DynamicPDF.HtmlConverter;
//using Microsoft.VisualBasic.Logging;
//using ceTe.DynamicPDF.Printing;

namespace DapperExample.Controllers
{
    public class HomeController : Controller
    {
       
        // GET: Home
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
        public ActionResult Index()
        {

             var Emp = EmployeeContext.ReturnList<EmployeeModel>("spr_getEmployeeDetails",null);
           // var Emp = con.Query<EmployeeModel>("spr_getEmployeeDetails", null);

            return View(Emp);
        }

        public ActionResult Create()
        {
           // ConversionOptions options = new ConversionOptions(PageSize.A4, PageOrientation.Portrait, 50.0f);
           // // Set Metadata for the PDF
           // options.Author = "Myself";
           // options.Title = "My Webpage";
           //// Set Header and Footer text
           // options.Header = "<div style=\"text-align:center;display:inline-block;width:100%;font-size:12px;\">" +
           //     "<span class=\"date\"></span></div>";
           // options.Footer = "<div style=\"text-align:center;display:inline-block;width:100%;font-size:12px;\">" +
           //     "Page <span class=\"pageNumber\"></span> of <span class=\"totalPages\"></span></div>";
           // //Convert with Options
           // Converter.Convert(new Uri("http://en.wikipedia.org"), "D:\\WithConversionOptions.pdf", options);
           // //PrintJob printJob = new PrintJob("Printer Name", "D:\\WithConversionOptions.pdf");
           // //printJob.Print();//https://localhost:44351/home/create
            return View();
        
        }

        //[HttpPost]
        //public ActionResult Create(EmployeeModel emp)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@empname",emp.EmpName);
        //    param.Add("@empsalary",emp.EmpSalary);

        //    try
        //    {
        //        int result = EmployeeContext.AddOrEdit<int>("spr_InsertEmployeeDetails", param);

        //        if (result > 0)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    catch(Exception ex)
        //    { 
            
           
        //    }

        //}

        public ActionResult Edit(int ? id)
        {
            var param = new DynamicParameters();
            param.Add("@empid", id);

            var Emp = EmployeeContext.ReturnList<EmployeeModel>("spr_getEmployeeDetailsbyId", param).SingleOrDefault();

            return View(Emp);

        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            var param = new DynamicParameters();
            param.Add("@Empid", emp.EmpId);
            param.Add("@EmpName", emp.EmpName);
            param.Add("@EmpSalary", emp.EmpSalary);
            bool result = EmployeeContext.AddOrEdit<bool>("spr_updateEmployeeDetails", param);

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

            var Emp = EmployeeContext.ReturnList<EmployeeModel>("spr_getEmployeeDetailsbyId", param).SingleOrDefault();

            return View(Emp);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            var param = new DynamicParameters();
            param.Add("@empid", id);
            
            bool result = EmployeeContext.AddOrEdit<bool>("spr_deleteEmployeeDetails", param);

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