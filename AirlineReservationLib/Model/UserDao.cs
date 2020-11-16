using Enum;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class UserDao
    {
        public UserDao(Guid id, string username, string firstName, string lastName, short age, List<Role> roles, string hashedPassword)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Roles = roles;
            HashedPassword = hashedPassword;
        }
        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public string Username { get; private set; }
        [DataMember]
        public string FirstName { get; private set; }
        [DataMember]
        public string LastName { get; private set; }
        [DataMember]
        public short Age { get; private set; }
        [DataMember]
        public List<Role> Roles { get; private set; }
        [DataMember]
        public string HashedPassword { get; private set; }
    }
}
