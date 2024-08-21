namespace HomeWork8Additional.Figures
{
    public abstract class Figure
    {
        public string Type { get; set; }
        public decimal Perimeter { get; set; }
        public abstract void GetPerimeter();
    }
}
