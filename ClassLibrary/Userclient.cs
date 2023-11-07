using AspCoreModel;
using AspCoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public partial class AoiClient
    {
        public async Task<List<UserModel>> GetUsers()
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/GetAll"));
            return await GetAsync<List<UserModel>>(requestUrl);
        }
        public async Task<Messages<UserModel>> SaveUser(UserModel user)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "User/SaveUser"));
            return await PostAsync<UserModel>(requestUrl, user);
        }
    }
}
