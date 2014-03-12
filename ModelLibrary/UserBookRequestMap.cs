using FluentNHibernate.Mapping;

namespace ModelLibrary
{
    public class UserBookRequestMap : ClassMap<UserBookRequest>
    {
        public UserBookRequestMap()
        {
            Table("lib_user_bookRequest");

            Id(ub => ub.Id);
            Map(ub => ub.Approval, "approval");
            Map(ub => ub.IsActive, "isActive");
            Map(ub => ub.CreatedDateTime, "CreatedDateTime");

            References(ub => ub.BookRequest).Column("bookRequest_id").Not.LazyLoad();
            References(ub => ub.User).Column("user_id").Not.LazyLoad();
        }
    }
}
