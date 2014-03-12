using ModelLibrary;

namespace ServiceLibrary
{
    public interface ISessionService
    {
        Session CreateSession(UserDto user);
    }
}