using System;
using System.Collections.Generic;
using ModelLibrary;

namespace DalLibrary
{
    public interface IUserBookRequestDal
    {
        Boolean Save(IList<UserBookRequest> userBookRequests);
        IList<UserBookRequest> Read(int userid);
        IList<UserBookRequest> ReadAllPending();
        IList<UserBookRequest> ReadAllActiveRequestsForUser(int userid);
        bool DeleteBookRequestForUser(IList<UserBookRequest> userBookRequestList);
        UserBookRequest GetUserBookRequestById(int returnid);
    }
}