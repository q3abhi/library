using System;
namespace ModelLibrary
{
    public class UserBookRequest
    {
        public virtual int Id { get; set; }
        public virtual BookRequest BookRequest { get; set; }
        public virtual User User { get; set; }
        public virtual int Approval { get; set; }
        public virtual int IsActive { get; set; }
        public virtual String CreatedDateTime { get; set; }


        public UserBookRequest()
        {
            BookRequest = new BookRequest();
            User = new User();
            CreatedDateTime = DateTime.Now.ToString();
        }

    }
}
