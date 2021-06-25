using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_Driver
{
    [Serializable]
    public class FirmCar
    {
        public string NameFirmCar { get; set; }

        public List<Car> Cars { get; set; }

        public FirmCar()
        {
            Cars = new List<Car>();
        }
        public void WriteAllCar()
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                Console.WriteLine(i + ". " + Cars[i]);
            }
            Console.WriteLine("\n");
        }
        public void AddCar(Car c)
        {
            Cars.Add(c);
            Console.WriteLine("\n");
        }
        public void DeleteCar(Car с)
        {
            Cars.Remove(с);
            Console.WriteLine("\n");
        }
    }
}
