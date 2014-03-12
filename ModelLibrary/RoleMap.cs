using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;

namespace ModelLibrary
{
    class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("lib_role");
            Id(role => role.Id, "id");
            Map(role => role.Name, "name");

            HasManyToMany(role => role.Users)
                .Table("lib_user_role")
                .ParentKeyColumn("role_id")
                .ChildKeyColumn("user_id")
                .Not.LazyLoad();

            HasManyToMany(role => role.Tokens)
                .Table("lib_role_token")
                .ParentKeyColumn("role_id")
                .ChildKeyColumn("token_id")
                .Not.LazyLoad();
        }
    }
}
