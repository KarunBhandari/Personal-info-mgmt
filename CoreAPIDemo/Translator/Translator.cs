using CoreAPIDemo.Model;
using System.Data.SqlClient;
using CoreAPIDemo.Utilities;

namespace CoreAPIDemo.Translator
{
    public static class Translator
    {
        public static UserModel TranslateAsUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();

            }


            var item = new UserModel();

            if (reader.IsColumnExists("Id"))
                item.Id = Helper.GetNullableInt32(reader, "Id");

            if(reader.IsColumnExists("Name"))
                item.Name = Helper.GetNullableString(reader, "Name");

            if (reader.IsColumnExists("EmailId"))
                item.Email = Helper.GetNullableString(reader, "EmailId");
            
            if(reader.IsColumnExists("Address"))
                item.Address = Helper.GetNullableString(reader, "Address");

            if(reader.IsColumnExists("Mobile"))
                item.Mobile = Helper.GetNullableString(reader, "Mobile");

            if(reader.IsColumnExists("IsActive"))
                item.IsActive = Helper.GetBoolean(reader, "IsActive");

            return item;
        }

        public static List<UserModel> TranslateAsUsersList(this SqlDataReader reader)
        {
            var list = new List<UserModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsUser(reader, true));
            }
            return list;
        }

    }
}
