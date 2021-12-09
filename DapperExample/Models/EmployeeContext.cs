using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace DapperExample.Models
{
    public static class EmployeeContext
    {
        //var Emp = EmployeeContext.ReturnList<EmployeeModel>("spr_getEmployeeDetails", null);

        public static IEnumerable<T> ReturnList<T>(string spName,DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
            return con.Query<T>(spName, param, commandType: System.Data.CommandType.StoredProcedure);
          
        }

         

        //public static int AddOrEdit(string spName, DynamicParameters param)
        //{
        //    SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
        //   var result= con.Execute(spName, param, commandType: System.Data.CommandType.StoredProcedure);
        //    return result;
        //}
        //TextBox1.Text="1;Delete from Emp"
        //@EmpId int=1;Delete

        //Sqlcommand("select * from Emp where id='"+Textbox1.Text+"',com)
        public static P AddOrEdit<P>(string spName, DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=true");
            var result = (P)Convert.ChangeType(con.Execute(spName, param, commandType: System.Data.CommandType.StoredProcedure),typeof(P));
            return result;
        }
    }
    }
