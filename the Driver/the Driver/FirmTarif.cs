using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_Driver
{
    [Serializable]
    public class FirmTarif
    {
        public string NameFirmTarif { get; set; }

        public List<Tarif> Tarifs { get; set; }

        public FirmTarif()
        {
            Tarifs = new List<Tarif>();
        }
        public void WriteAllTarif()
        {
            for (int iii = 0; iii < Tarifs.Count; iii++)
            {
                Console.WriteLine(iii + ". " + Tarifs[iii]);
            }
            Console.WriteLine("\n");
        }
        public void AddTarif(Tarif t)
        {
            Tarifs.Add(t);
            Console.WriteLine("\n");
        }
        public void DeleteTarif(Tarif t)
        {
            Tarifs.Remove(t);
            Console.WriteLine("\n");
        }
    }
}
