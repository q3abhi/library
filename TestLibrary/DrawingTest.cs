using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestLibrary
{
    [TestClass]
    public class DrawingTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            String[] a = new[] {"Sdfsd"};
            Drawing.Main(a);
        }
    }
}
