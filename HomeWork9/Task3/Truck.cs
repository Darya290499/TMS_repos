namespace HomeWork9.Task3
{
    public class Truck : Car
    {
        public const int minTunkVolume = 150;

        public const int maxTunkVolume = 500; 
        public Truck() { }

        public Truck(int fuelAmount, int consumption, int tunkVolume) : base(fuelAmount, consumption, tunkVolume) { }
    }
}
