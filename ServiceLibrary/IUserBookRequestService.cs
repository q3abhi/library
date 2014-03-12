using System;
using System.Collections.Generic;
using ModelLibrary;

namespace ServiceLibrary
{
    public interface IUserBookRequestService
    {
        Boolean Add(int userid, int bookid);
        IList<UserBookRequest> ReadAllActiveRequestsForUser(int userid);
        Boolean DeleteBookRequestForUser(int returnid);
        Boolean ApproveBookRequestForUser(int requestid);

    }
}