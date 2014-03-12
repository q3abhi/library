using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelLibrary;

namespace ModelLibrary
{
    public class Hiber
    {
        public void Save()
        {
            User user = new User();
            user.Name = "sdfsdf";
            user.Age = 33;
            user.Password = "sdfsdf";
            user.Username = "sdfsdf";
            Console.Write("Calling FLuent");
            FluentDal dal = new FluentDal();
            dal.MakeConnnection();
            //       Hdal dal = new Hdal();
            //       dal.MakeConnection(user);
        }

  /*      static void Main(String[] arg)
        {
            Hiber hib = new Hiber();
            hib.Save();
            Console.Write("Done");
        }*/
        
    }


}
