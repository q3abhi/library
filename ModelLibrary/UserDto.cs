using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLibrary
{
    public class UserDto
    {
        public int Id;
        public String Name;
        public String Username;
        public int Age;
        public String[] Roles;
        public String[] Memberships;
        public IList<String> Tokens;
    }
}
