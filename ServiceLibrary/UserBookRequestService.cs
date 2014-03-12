using System;
using System.Collections;
using System.Collections.Generic;
using DalLibrary;
using ModelLibrary;

namespace ServiceLibrary
{
    public class UserBookRequestService : IUserBookRequestService
    {
        public Boolean Add(int userid, int bookid)
        {
            try
            {
                var bookRequestService = new BookRequestService();
                BookRequest bookRequest = bookRequestService.GetByBook(bookid);

                var userService = new UserService();
                User user = userService.GetUserById(userid);

                var userBookRequest = new UserBookRequest {User = user, BookRequest = bookRequest, IsActive = 1};

                IList<UserBookRequest> userBookRequestList = new List<UserBookRequest>();
                userBookRequestList.Add(userBookRequest);

                var userBookRequestDal = new UserBookRequestDal();
                Boolean status = userBookRequestDal.Save(userBookRequestList);

                return status;

            }
            catch (Exception e)
            {
                Console.WriteLine("Some error in UserBookRequestService , Add()");
                Console.Write(e.ToString());
                return false;
            }

        }


        public IList<UserBookRequest> ReadAllActiveRequestsForUser(int userid)
        {
            try
            {
                var userBookRequestDal = new UserBookRequestDal();
                IList<UserBookRequest> userBookRequestList = userBookRequestDal.ReadAllActiveRequestsForUser(userid);
                IList<BookRequest> bookRequestList = new List<BookRequest>();

                return userBookRequestList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Some error in UserBookRequestService , Read()");
                Console.Write(e.ToString());
                return null;
            }
            
        }

        public bool DeleteBookRequestForUser(int returnid)
        {
            try
            {
                IUserBookRequestDal userBookRequestDal = new UserBookRequestDal();
                UserBookRequest userBookRequest = userBookRequestDal.GetUserBookRequestById(returnid);
                userBookRequest.IsActive = 0;
                IList<UserBookRequest> userBookRequestList = new List<UserBookRequest>();
                userBookRequestList.Add(userBookRequest);
                Boolean status = userBookRequestDal.DeleteBookRequestForUser(userBookRequestList);

                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.Write("Some error in UserBookRequestService , DeleteBookRequestForUser()");
                return false;
            }
        }

        public bool ApproveBookRequestForUser(int requestid)
        {
            try
            {
                IUserBookRequestDal userBookRequestDal = new UserBookRequestDal();
                UserBookRequest userBookRequest = userBookRequestDal.GetUserBookRequestById(requestid);
                userBookRequest.Approval = 1;
                IList<UserBookRequest> userBookRequestList = new List<UserBookRequest>();
                userBookRequestList.Add(userBookRequest);
                Boolean status = userBookRequestDal.DeleteBookRequestForUser(userBookRequestList);

                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.Write("Some error in UserBookRequestService, ApproveBookRequestForUser()");
                return false;
            }
            
        }
    }
}

