namespace HomeWork8Additional.Figures
{
    public class Circle : Figure
    {
        public decimal R {  get; set; }
        protected decimal pi = 3.14m;

        public Circle() { }
        public Circle(decimal r)
        {
            R = r;
            Type = "Круг";
            GetPerimeter();
        }

        public override void GetPerimeter()
        {
            Perimeter = 2 * pi * R; 
        }
    }
}
