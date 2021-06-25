using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_Driver
{
    [Serializable]
    public class User
    {
        public string NameUser { get; set; }
        public int OldUser { get; set; }
        public int StajUser { get; set; }

        public int CarDocUser { get; set; }
        public int РassportUser { get; set; }
        public int CreditCartUser { get; set; }
        public int MobileNumberUser { get; set; }



        public override string ToString()
        {
            return String.Join(" ", NameUser, OldUser, StajUser, CarDocUser, РassportUser, CreditCartUser, MobileNumberUser);
        }

        public void ReadDataUser()
        {
            Console.Write("Введите ФИО пользователя: ");
            NameUser = Console.ReadLine();
            Console.Write("Введите возраст пользователя: ");
            OldUser = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите стаж вождения польователя: ");
            StajUser = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите водительское удостоверение пользователя: ");
            CarDocUser = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите паспорт пользователя: ");
            РassportUser = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите реквезиты банковской карты: ");
            CreditCartUser = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите мобильный номер: ");
            MobileNumberUser = Convert.ToInt32(Console.ReadLine());
        }
    }
}
