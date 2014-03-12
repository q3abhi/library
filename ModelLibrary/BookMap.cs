using FluentNHibernate.Mapping;

namespace ModelLibrary
{
    class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("lib_book");

            Id(m => m.Id);
            Map(m => m.Name, "name");
            Map(m => m.Description, "description");
            Map(m => m.Author, "author");
            Map(m => m.Copies, "copies");
            Map(m => m.Price, "price");
            Map(m => m.Publisher, "publisher");
            Map(m => m.ToBeIssued, "copies_for_issue");

            HasOne(m => m.BookRequest).Not.LazyLoad();

        }
    }
}
