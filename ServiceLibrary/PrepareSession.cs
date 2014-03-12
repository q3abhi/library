using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLibrary;

namespace ServiceLibrary
{
    public class PrepareSession : IPrepareSession
    {
        public Session Prepare(UserDto userDto)
        {
            if (userDto!= null)
            {                
                Session session = new Session();
                session.UserId = userDto.Id;
                session.Name = userDto.Name;
                session.Age = userDto.Age;
                session.Username = userDto.Username;
                session.LoggedIn = true;
                session.DateTime = DateTime.Now;                
                session.Roles = userDto.Roles;
                session.Memberships = userDto.Memberships;
                session.Tokens = userDto.Tokens;

                return session;
            }

            else
            {
                return null;
            }
            
            
        }
    }
}
