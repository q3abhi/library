using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLibrary
{
    public class Token
    {
        private int _id;
        private String _name;
        private IList<Role> _roles; 

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

        public virtual IList<Role> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        public Token()
        {
            _roles = new List<Role>();
        }
    }
}
