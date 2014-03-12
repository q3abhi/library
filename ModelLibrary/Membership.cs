using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary
{
    public class Membership
    {
        private int _id;
        private String _name;
        private String _description;
        private int _allowedWeeks;
        private int _allowedBooks;
        private int _allowedBookreturns;
        private int _allowedMagzines;
        private int _amount;

        private IList<User> _users;

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public virtual int AllowedWeeks
        {
            get { return _allowedWeeks; }
            set { _allowedWeeks = value; }
        }

        public virtual int AllowedBooks
        {
            get { return _allowedBooks; }
            set { _allowedBooks = value; }
        }

        public virtual int AllowedBookreturns
        {
            get { return _allowedBookreturns; }
            set { _allowedBookreturns = value; }
        }

        public virtual int AllowedMagzines
        {
            get { return _allowedMagzines; }
            set { _allowedMagzines = value; }
        }

        public virtual int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public virtual IList<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public Membership()
        {
            _users = new List<User>();
        }
    }
}
