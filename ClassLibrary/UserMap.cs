using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLibrary;
using NHibernate.Mapping;
using FluentNHibernate.Mapping;

namespace ClassLibrary
{
    
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("lib_user");
            Id(user => user.Id,"id");
            Map(user => user.Name, "name");
            Map(user => user.Username, "username");
            Map(user => user.Password, "password");
            Map(user => user.Age, "age");
        }
    }
}
