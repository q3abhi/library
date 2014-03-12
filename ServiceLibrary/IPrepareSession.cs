using ModelLibrary;

namespace ServiceLibrary
{
    public interface IPrepareSession
    {
        Session Prepare(UserDto userDto);
    }
}