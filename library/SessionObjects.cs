using System;
using System.Collections.Generic;
using ModelLibrary;
using ServiceLibrary;

namespace library
{
    public class SessionObjects
    {
        private SessionObjects() {}

        private static SessionObjects _sessionObj;

        private static Dictionary<int,Session> _sessionMap = new Dictionary<int,Session>(); 
          
        public static SessionObjects CreateInstance()
        {
            if (_sessionObj == null)
            {
                _sessionObj = new SessionObjects();
            }

            return _sessionObj;
        }

        public Session CreateSession(UserDto user)
        {
            if (user != null)
            {
                ISessionService sessionService = new SessionService();
                Session session = sessionService.CreateSession(user);
                _sessionMap.Add(user.Id, session);
                return session;
            }

            return null;
        }

        public Session GetSession(int id)
        {
            if (_sessionMap.ContainsKey(id))
            {
                Session session = _sessionMap[id];
                return session;
            }
            return null;
        }

        public Boolean CheckSession(int id)
        {
            if (_sessionMap.ContainsKey(id))
            {
                return true;
            }
            return false;

        }

        public Boolean DeleteSession(int id)
        {
            Boolean status = _sessionMap.Remove(id);
            return status;
        }
    }
    
}