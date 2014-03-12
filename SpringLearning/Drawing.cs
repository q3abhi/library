using System;
using Spring.Context;
using Spring.Context.Support;

namespace TestLibrary
{
    public class Drawing
    {
        public static void Main(String[] arg)
        {
            IApplicationContext context = ContextRegistry.GetContext();
            Triangle tri = (Triangle)context.GetObject("triangle");
            tri.Draw();
        }
    }
}
