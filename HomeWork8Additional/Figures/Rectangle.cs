using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8Additional.Figures
{
    public class Rectangle : Figure
    {
        public decimal SideA { get; set; }
        public decimal SideB { get; set; }
        public Rectangle() { }
        public Rectangle(decimal sideA, decimal sideB)
        {
            SideA = sideA;
            SideB = sideB;
            Type = "Прямоугольник";
            GetPerimeter();
        }
        public override void GetPerimeter()
        {
            Perimeter = SideA * 2 + SideB * 2;
        }
    }
}
