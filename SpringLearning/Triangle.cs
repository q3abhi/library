using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLibrary
{
    class Triangle : IShape
    {
        public IShape implementsShape { get; set; }
        public void Draw()
        {
            implementsShape.Draw();
            Console.WriteLine("Triangle drawn");
        }
    }
}
