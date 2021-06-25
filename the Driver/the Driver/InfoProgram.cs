using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_Driver
{
    abstract class InfoProgram
    {
        public abstract string Write();
    }

    class INFOPROGRAM : InfoProgram
    {
        public override string Write()
        {
            Console.WriteLine("О программе\n");
            Console.WriteLine("--------------");
            Console.WriteLine("| the Driver | ");
            Console.WriteLine("--------------\n");
            Console.WriteLine("Автор программы: Манахов Ф.И.");
            Console.WriteLine("Версия 1.0");
            Console.WriteLine("Все права защищены");
            Console.WriteLine("2019\n");
            return "Нажмите любую кнопку, чтобы вернуться в меню ...";
        }
    }
}
