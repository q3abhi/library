using ModelLibrary;

namespace ServiceLibrary
{
    public interface IPrepareUserDto
    {
        UserDto Prepare(User user);
    }
}