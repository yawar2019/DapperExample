using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;
namespace DapperExample2.Models
{
    public static class ReturnData
    {
        public static IEnumerable<T> ReturnList<T>(string SpName,DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Employee");
            return con.Query<T>(SpName, param, commandType: CommandType.StoredProcedure);
        }

        //public static int AddOrSave(string SpName, DynamicParameters param)
        //{
        //    SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Employee");
        //    int result= con.Execute(SpName, param, commandType: CommandType.StoredProcedure);//1
        //    return result;
        //}

        //public static bool AddOrSave1(string SpName, DynamicParameters param)
        //{
        //    SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Employee");
        //    bool result =(bool) Convert.ChangeType(con.Execute(SpName, param, commandType: CommandType.StoredProcedure), typeof(bool));
        //    return result;
        //}

        public static P AddOrSave<P>(string SpName, DynamicParameters param)
        {
            SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Integrated Security=true;Initial Catalog=Employee");
            var result = (P)Convert.ChangeType(con.Execute(SpName, param, commandType: CommandType.StoredProcedure), typeof(P));
            return result;
        }


    }
}