using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace LoginCrudOperation.Models
{
    public class LoginContext
    {
        SqlConnection con = new SqlConnection("Data Source=AZAM-PC\\SQLEXPRESS;Initial Catalog=LoginDapperDb;Integrated Security=true");

        public List<LoginModel> GetUserLogins()
        {
           var loginUsers= con.Query<LoginModel>("usp_getLoginUser",commandType:CommandType.StoredProcedure).ToList();
           return loginUsers;
        }

        public int SaveUserLogin(LoginModel logUser)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserName", logUser.UserName);
            parameter.Add("@Password", logUser.Password);

            int result= con.Execute("usp_InsertLoginUser",param:parameter, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
