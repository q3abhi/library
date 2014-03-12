    using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernate.Linq;
using NHibernate.Mapping;

namespace ModelLibrary
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

            HasManyToMany<Role>(user => user.Roles)
                .Table("lib_user_role")
                .ParentKeyColumn("user_id")
                .ChildKeyColumn("role_id")
                .Not.LazyLoad();

            HasManyToMany<Membership>(m => m.Memberships)
                .Table("lib_user_membership")
                .ParentKeyColumn("user_id")
                .ChildKeyColumn("membership_id")
                .Not.LazyLoad();

            HasManyToMany<BookRequest>(u => u.BookRequests)
                .Table("lib_user_bookRequest")
                .ParentKeyColumn("user_id")
                .ChildKeyColumn("bookRequest_id")
                .Not.LazyLoad();
        }
    }
}
