using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLibrary
{
    [TestClass]
    public class HiberTest
    {
        [TestMethod]
        public void TestHiber()
        {
            Hiber hib = new Hiber();
            Console.Write("Calling...");
            hib.Save();
            
        }
    }
}
