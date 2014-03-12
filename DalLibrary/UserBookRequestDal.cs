using System;
using System.Collections.Generic;
using System.Linq;
using ModelLibrary;

namespace DalLibrary
{
    public class UserBookRequestDal : IUserBookRequestDal
    {
        public Boolean Save(IList<UserBookRequest> userBookRequests)
        {
            try
            {
                IDal<UserBookRequest> dal = new Dal<UserBookRequest>();
                Boolean status = dal.Save(userBookRequests);

                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in BookRequest Dal, Add()");
                Console.Write(e.ToString());
                return false;
            }
            
        }


        public IList<UserBookRequest> Read(int userid)
        {
            try
            {
                String query = "From UserBookRequest br where br.User.Id=" + userid;
                IDal<UserBookRequest> dal = new Dal<UserBookRequest>();
                IList<UserBookRequest> userBookRequestList = dal.Read(query);

                return userBookRequestList;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error at UserbookRequestDal , Read()");
                Console.Write(e.ToString());
                return null;
            }
        }

        public IList<UserBookRequest> ReadAllPending()
        {
            try
            {
                String query = "From UserBookRequest br where br.Approval=0";
                IDal<UserBookRequest> dal = new Dal<UserBookRequest>();
                IList<UserBookRequest> userBookRequestList = dal.Read(query);

                return userBookRequestList;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error at UserbookRequestDal , ReadPending()");
                Console.Write(e.ToString());
                return null;
            }
        }

        public IList<UserBookRequest> ReadAllActiveRequestsForUser(int userid)
        {
            try
            {
                String query = "From UserBookRequest br " +
                               "where br.User.Id=" + userid + " and br.IsActive=1";
                IDal<UserBookRequest> dal = new Dal<UserBookRequest>();
                IList<UserBookRequest> userBookRequestList = dal.Read(query);

                return userBookRequestList;
            }

            catch (Exception e)
            {
                Console.WriteLine("Error at UserbookRequestDal , ReadAllRequestsForUser()");
                Console.Write(e.ToString());
                return null;
            }
        }


        public bool DeleteBookRequestForUser(IList<UserBookRequest> userBookRequestList)
        {
            try
            {
                IDal<UserBookRequest> dal = new Dal<UserBookRequest>();
                Boolean status = dal.Save(userBookRequestList);
                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error at UserbookRequestDal , DeleteBookRequestForUser()");
                Console.Write(e.ToString());
                return false;
            }
            
        }

        public UserBookRequest GetUserBookRequestById(int returnid)
        {
            try
            {
                String query = "From UserBookRequest br where br.Id=" + returnid;
                IDal<UserBookRequest> dal = new Dal<UserBookRequest>();
                IList<UserBookRequest> userBookRequestList =  dal.Read(query);
                UserBookRequest userBookRequest = userBookRequestList.FirstOrDefault();
                return userBookRequest;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error at UserbookRequestDal , GetUserBookRequestById()");
                Console.Write(e.ToString());
                return null;
            }
        }



    }
}
