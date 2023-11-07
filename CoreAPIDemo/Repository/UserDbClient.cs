using CoreAPIDemo.Model;
using CoreAPIDemo.Translator;
using CoreAPIDemo.Utilities;
using System.Data;
using System.Data.SqlClient;

namespace CoreAPIDemo.Repository
{
    public class UserDbClient
    {
        public List<UserModel> GetAllUsers(string connectionstring)
        {
            return Helper.ExecuteProcedureReturnData<List<UserModel>>(connectionstring, "GetUsers", r => r.TranslateAsUsersList());
        }

        public string SaveUser(UserModel user, string connectionstring) 
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", user.Id),
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@EmailId", user.Email),
                new SqlParameter("@Mobile", user.Name),
                new SqlParameter("@Address", user.Email),
                outParam
            };
            Helper.ExecuteProcedureReturnString<string>(connectionstring, "SaveUser", parameters);
            return (string)outParam.Value;
        }

        public string DeleteUser(int id, string connectionstring)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction= ParameterDirection.Output
            };
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", id), outParam
            };

            Helper.ExecuteProcedureReturnString<string> (connectionstring, "DeleteUser", parameters);
            return (string)outParam.Value;
        }

        
    }
}
