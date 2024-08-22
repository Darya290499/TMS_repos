namespace HomeWork9.Task3
{
    public abstract class Car : IVehical
    {
        public int FuelAmount { get; set; }
        public int Consumption { get; set; } //расход на 100км
        public int TunkVolume { get; set; }

        public Car() { }
        public Car(int fuelAmount, int consumption)
        {
            FuelAmount = fuelAmount;
            Consumption = consumption;
        }

        public Car(int fuelAmount, int consumption, int tunkVolume)
        {
            FuelAmount = fuelAmount;
            Consumption = consumption;
            TunkVolume = tunkVolume;
        }

        public void Drive(int distance)
        {
            Console.WriteLine();
            if (FuelAmount == 0)
                Console.WriteLine($"Топливо в топливном баке отсутсвует");

            var fuelForDistance = Math.Round((decimal)Consumption / 100 * distance);
            Console.WriteLine($"На поездку необходимо {fuelForDistance}л топлива");
            OutputFuelAmount();
            OutputTunkVolume();
            if (fuelForDistance > TunkVolume)
            {
                if (FuelAmount == TunkVolume)
                    Console.WriteLine($"На данный момент топливный бак заправлен полностью");
                else
                    Console.WriteLine($"На данный момент можно заправить машину на {TunkVolume - FuelAmount}л до полного бака");
                Console.WriteLine($"Позже необходимо дозаправить машину на {fuelForDistance - TunkVolume}");
            }
            else if (FuelAmount >= fuelForDistance)
                Console.WriteLine($"На данный момент топлива в топливном баке хватит на всю поездку");
            else
                Console.WriteLine($"На данный момент для успешной поездки необходимо заправить машину на {fuelForDistance - FuelAmount}л");

        }

        public bool Refuel(int fuelAmount)
        {
            if(FuelAmount + fuelAmount <= TunkVolume)
            {
                FuelAmount += fuelAmount;
                Console.WriteLine($"Машина заправлена");
                return true;
            }
            Console.WriteLine($"Невозможно дозаправить машину на указанное количество топлива, поскольку объем топливного бака меньше");
            return false;
        }

        public void OutputFuelAmount() => Console.WriteLine($"Количество топлива в баке {FuelAmount}");
        public void OutputTunkVolume() => Console.WriteLine($"Объем топливного бака: {TunkVolume}");
    }
}
