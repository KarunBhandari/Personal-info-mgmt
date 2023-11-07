using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AspCoreModel
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }

        [DataMember(Name ="Name")]
        public string Name { get; set; }

        [DataMember(Name="Email")]
        public string EmailId { get; set; }

        [DataMember(Name = "Mobile")]
        public string Mobile { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
