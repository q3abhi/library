using System;
using System.Collections;
using System.Collections.Generic;

namespace ModelLibrary
{
    public sealed class Session
    {
        private int _userId;
        private string _username;                
        private string _name;
        private int _age;        
        private bool _loggedIn;
        private DateTime _dateTime;
        private String[] _memberships;
        private String[] _roles;
        private IList<String> _tokens;
        private int _allowedBooks;
      


        public string Username
        {
            get { return _username; }
            set { _username = value; }
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

        public bool LoggedIn
        {
            get { return _loggedIn; }
            set { _loggedIn = value; }
        }

        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public IList<string> Tokens
        {
            get { return _tokens; }
            set { _tokens = value; }
        }

        public string[] Memberships
        {
            get { return _memberships; }
            set { _memberships = value; }
        }

        public string[] Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public int AllowedBooks
        {
            get { return _allowedBooks; }
            set { _allowedBooks = value; }
        }

        public Session()
        {
            Tokens = new List<string>();
        }
    }
}
