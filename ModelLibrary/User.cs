using System.Collections.Generic;

namespace ModelLibrary
{
    public class User
    {
        private IList<Membership> _memberships; 
        private IList<Role> _roles;
        private IList<BookRequest> _bookRequests;


        public virtual string Username { get; set; }

        public virtual string Password { get; set; }

        public virtual string Name { get; set; }

        public virtual int Age { get; set; }

        public virtual int Id { get; set; }

        public virtual IList<Membership> Memberships
        {
            get { return _memberships; }
            set { _memberships = value; }
        }

        public virtual IList<Role> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        public virtual IList<BookRequest> BookRequests
        {
            get { return _bookRequests; }
            set { _bookRequests = value; }
        }

        public User()
        {
            _memberships = new List<Membership>();
            _roles = new List<Role>();
            _bookRequests = new List<BookRequest>();
        }

    }
}   