using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8Additional.Figures
{
    public class Triangle : Rectangle
    {
        public decimal SideC { get; set; }

        public Triangle() : base() { }
        public Triangle(decimal sideA, decimal sideB, decimal sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            Type = "Треугольник";
            GetPerimeter();
        }

        public override void GetPerimeter() =>
            Perimeter = SideA + SideB + SideC;
        
    }
}
