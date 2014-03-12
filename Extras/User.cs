using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelLibrary
{
    public class User
    {
        public int _age;
        public string _username;
        public string _password;
        public string _name;
        public int _id;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}