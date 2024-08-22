namespace HomeWork9.Task3
{
    public class SportsCar : Car
    {
        public const int minTunkVolume = 50;

        public const int maxTunkVolume = 120;
        public SportsCar() { }

        public SportsCar(int fuelAmount, int consumption, int tunkVolume) : base(fuelAmount, consumption, tunkVolume) { }
    }
}
