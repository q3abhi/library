using ModelLibrary;

namespace ServiceLibrary
{
    public class SessionService : ISessionService
    {
        public Session CreateSession(UserDto user)
        {

                IPrepareSession prepareSession = new PrepareSession();
                Session session = prepareSession.Prepare(user);
                return session;

        }

  
    }
}
