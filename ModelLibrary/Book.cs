using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelLibrary
{
    public class Book
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual string Author { get; set; }

        public virtual int Price { get; set; }

        public virtual int Copies { get; set; }

        public virtual string Publisher { get; set; }

        public virtual int ToBeIssued { get; set; }

        public virtual BookRequest BookRequest { get; set; }

    }
}
