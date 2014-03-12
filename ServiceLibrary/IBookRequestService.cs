using System;
using System.Collections.Generic;
using ModelLibrary;

namespace ServiceLibrary
{
    public interface IBookRequestService
    {
        Boolean Add(int bookid);
        IList<UserBookRequest> FetchAllPendingRequests();
        IList<UserBookRequest> ReadAllRequestsForUser(int userid);
    }
}