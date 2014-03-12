using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace ModelLibrary
{
    public class TokenMap : ClassMap<Token>
    {
        public TokenMap()
        {
            Table("lib_token");
            Id(t => t.Id,("id"));
            Map(t => t.Name, ("token_name"));
            HasManyToMany(t => t.Roles)
                .Table("lib_role_token")
                .ParentKeyColumn("token_id")
                .ChildKeyColumn("role_id")
                .Not.LazyLoad();
        }
    }
}
