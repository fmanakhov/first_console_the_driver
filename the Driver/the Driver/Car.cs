using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_Driver
{
    [Serializable]
    public class Car
    {
        public string NameCar { get; set; }
        public string ModelCar { get; set; }
        public string ColorCar { get; set; }

        public int YearCar { get; set; }
        public int VinCar { get; set; }
        public int PTSCar { get; set; }
        public int OsagoCar { get; set; }



        public override string ToString()
        {
            return String.Join(" ", NameCar, ModelCar, ColorCar, YearCar, VinCar, PTSCar, OsagoCar);
        }

        public void ReadDataCar()
        {
            Console.Write("Введите марку авто: ");
            NameCar = Console.ReadLine();
            Console.Write("Введите модель авто: ");
            ModelCar = Console.ReadLine();
            Console.Write("Введите цвет авто: ");
            ColorCar = Console.ReadLine();
            Console.Write("Введите год выпуска авто: ");
            YearCar = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите VIN кузова авто: ");
            VinCar = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ПТС авто: ");
            PTSCar = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ОСАГО авто: ");
            OsagoCar = Convert.ToInt32(Console.ReadLine());
        }
    }
}
