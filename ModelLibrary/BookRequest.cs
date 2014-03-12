using System.Collections.Generic;

namespace ModelLibrary
{
    public class BookRequest
    {
        private int _id;
        private string _description;
        private Book _book;
        private IList<User> _users; 

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public virtual Book Book
        {
            get { return _book; }
            set { _book = value; }
        }

        public virtual IList<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }


        public BookRequest()
        {
            Book = new Book();
            _users = new List<User>();
        }
    }
}
