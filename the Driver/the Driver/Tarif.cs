using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_Driver
{
    [Serializable]
    public class Tarif
    {
        public int PriceTarif { get; set; }
        public string InfoTarif { get; set; }

        public override string ToString()
        {
            return String.Join(" ", PriceTarif, InfoTarif);
        }

        public void ReadDataTarif()
        {
            Console.Write("Введите сумму тарифа (руб/мин): ");
            PriceTarif = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите описание тарифа: ");
            InfoTarif = Console.ReadLine();
        }
    }
}
