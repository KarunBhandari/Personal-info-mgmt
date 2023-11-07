using Microsoft.AspNetCore.Mvc;
using CoreAPIDemo.Utilities;
using CoreAPIDemo.Model;
using Microsoft.Extensions.Options;
using CoreAPIDemo.Repository;

namespace CoreAPIDemo.Controllers
{
    [ApiController]
    //[Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IOptions<MySettingModel> appoptions;

            public UserController(IOptions<MySettingModel> options)
        {
            appoptions = options;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllUsers()
        {
            var dbValue = appoptions.Value.DbConnection;
            var users = DbClientFactory<UserDbClient>.Instance.GetAllUsers(dbValue);
            return Ok(users);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult SaveUser([FromBody]UserModel user)
        {
            var msg = new Message<UserModel>();
            var data = DbClientFactory<UserDbClient>.Instance.SaveUser(user, appoptions.Value.DbConnection);
            if(data == "C200")
            {
                msg.IsSuccess = true;
                if(user.Id == 0)
                {
                    msg.ReturnMessage = "User saved successfully";
                }
                else
                {
                    msg.ReturnMessage = "User updated successfully";
                }
            }
            else if(data == "C201")
            {
                msg.IsSuccess= false;
                msg.ReturnMessage = "Email Id already exists";
            }
            else if(data == "C202")
            {
                msg.IsSuccess= false;
                msg.ReturnMessage = "Mobile Number already exists";
            }
            return Ok(msg);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteUser([FromBody]UserModel userModel) {
        var msg = new Message<UserModel>();
            var data = DbClientFactory<UserDbClient>.Instance.DeleteUser(userModel.Id, appoptions.Value.DbConnection);
            if (data == "C200")
            { msg.IsSuccess = true;
                msg.ReturnMessage = "User Dewleted";

            }
            else if(data =="203")
            {
                msg.IsSuccess= false;
                msg.ReturnMessage = "Invalid record";
            }
            return Ok(msg) ;
        }

    }
}
