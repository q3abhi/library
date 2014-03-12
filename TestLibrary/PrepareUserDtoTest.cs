using System;
using System.Linq;
using DalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;
using ServiceLibrary;

namespace TestLibrary
{
    [TestClass]
    public class PrepareUserDtoTest
    {
        private PrepareUserDto prepareDto;

        [TestMethod]
        public void TestPrepare()
        {
            User user = new User();

            user.Username = "quaker";
            user.Password = "abhishek";

            IUserDal dal =new UserDal();
            User returnedUser = dal.ValidateUser(user);
            prepareDto = new PrepareUserDto();
            UserDto dto = prepareDto.Prepare(returnedUser);

            Console.Write(dto.Name);

            String[] mem = dto.Memberships;

            for (int count = 0; count < mem.Length; count++)
            {
                Console.Write(mem[count]);
            }

            for (int i = 0; i < dto.Tokens.Count; i++)
            {
                Console.WriteLine(dto.Tokens[i]);
            }

            Assert.IsNotNull(dto,"Should not be null");
        }
    }
}
