using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;

namespace ModelLibrary
{
    public class MembershipMap : ClassMap<Membership>
    {
        public MembershipMap()
        {
            Table("lib_membership");

            Id(m => m.Id, "id");
            Map(m => m.Name, "name");
            Map(m => m.Description, "description");
            Map(m => m.AllowedBookreturns, "allowed_books_returns");
            Map(m => m.AllowedBooks, "allowed_books");
            Map(m => m.AllowedMagzines, "allowed_magazines");
            Map(m => m.AllowedWeeks, "allowed_weeks");

            HasManyToMany(m => m.Users)
                .Table("lib_user_membership")
                .ParentKeyColumn("membership_id")
                .ChildKeyColumn("user_id")
                .Not.LazyLoad();

        }
    }
}
