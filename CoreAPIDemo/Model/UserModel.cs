﻿using System.Runtime.Serialization;

namespace CoreAPIDemo.Model
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name ="Id")]
        public int Id { get; set; }
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "EmailId")]
        public string Email { get; set; }

        [DataMember(Name = "Mobile")]
        public string Mobile { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }
    }

    [DataContract]
    public class Message<T>
    {
        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }

        [DataMember(Name ="ReturnMessage")]
        public string ReturnMessage { get; set; }

        [DataMember(Name ="Data")]
        public T Data { get; set; }
    }
}
