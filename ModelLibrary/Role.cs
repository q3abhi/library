using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary
{
    public class Role
    {

        private int _id;
        private String _name;
        private int _hierarchy;
        private IList<User> _users;
        private IList<Token> _tokens; 

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual int Hierarchy
        {
            get { return _hierarchy; }
            set { _hierarchy = value; }
        }

        public virtual IList<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public virtual IList<Token> Tokens
        {
            get { return _tokens; }
            set { _tokens = value; }
        }

        public Role()
        {
            _users = new List<User>();
            _tokens = new List<Token>();
        }
    }
}
