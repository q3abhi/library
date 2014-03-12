using FluentNHibernate.Mapping;

namespace ModelLibrary
{
    public class BookRequestMap : ClassMap<BookRequest>
    {
        public BookRequestMap()
        {
            Table("lib_bookRequest");

            Id(b => b.Id);
            Map(b => b.Description, "description");
            References(b => b.Book).Column("book_id").Not.LazyLoad();

            HasManyToMany(b => b.Users)
                .Table("lib_user_bookRequest")
                .ParentKeyColumn("bookRequest_id")
                .ChildKeyColumn("user_id")
                .Not.LazyLoad();
        }  
    }
}
