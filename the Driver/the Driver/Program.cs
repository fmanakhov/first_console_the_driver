using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace the_Driver
{
    abstract class Program : InfoProgram
    {
        static void Action(Ieula eula)
        {
            eula.EULA();
        }
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--------------");
            Console.WriteLine("| the Driver | ");
            Console.WriteLine("--------------\n");
            Console.WriteLine("Добро пожаловать!\n");
            Console.WriteLine("                                                                      ");
            Console.WriteLine("                                                                      ");
            Console.WriteLine("                 -sdmmmmmNmmmmmNmmmmNmmmmdy/                          ");
            Console.WriteLine("               .hMMmyssssssssNMMyssssssssdMMm-                        ");
            Console.WriteLine("              +NMN/          mMM.         -mMMs`                      ");
            Console.WriteLine("            .hMMh.           mMM.           sMMm-                     ");
            Console.WriteLine("           +NMN/             mMM.            -mMMs`                   ");
            Console.WriteLine(" ````````-hMMd-``````````````mMM-`````````````.yMMm:.`````````        ");
            Console.WriteLine("mMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNds-   ");
            Console.WriteLine("MMN++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++smMMh` ");
            Console.WriteLine("MMN                                                              +MMm`");
            Console.WriteLine("MMN        `:/++:`          the Driver              .:++/:`       oMMo");
            Console.WriteLine("MMN      /dMMMMMMMm+`                            `+mMMMMMMMd/     `MMN");
            Console.WriteLine("MMN----:dMMh/.``:yMMm:--------------------------:mMMy:.`./hMMh-----MMM");
            Console.WriteLine("NMMMMMMMMMo       /MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM/       oMMMMMMMMMN");
            Console.WriteLine("`:::--:hMM:       .MMm:::-------------------:-::NMM.       :MMh:----:`");
            Console.WriteLine("       :MMm-     .dMM+                          +MMd.     -mMM:       ");
            Console.WriteLine("        -mMMmysymMMm/                            /mMMdysymMMm-        ");
            Console.WriteLine("          :shmmmds:                                :sdmmmhs-          ");
            Console.WriteLine("                                                                      ");
            Console.WriteLine("\nПрочитать пользовательское соглашение? (да/нет)\n");
            string select_start = Console.ReadLine();
            switch (select_start)
            {
                case "да":
                    Console.Clear();
                    InfoEula infoEula = new InfoEula();
                    Action(infoEula);
                    break;
                case "нет":
                    Console.Clear();
                    Console.WriteLine("Вы не прочитали пользовательское соглашение, поэтому вы не можете воспользоваться программой !\n");
                    Console.WriteLine("Программа выключиться через 10 сек ");
                    Thread.Sleep(10000);
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Main();
                    break;
            }
            Console.ReadLine();
            Console.Clear();
            Menu();
            Console.ReadLine();
        }
        private static void Menu()
        {
            Console.WriteLine(" ------");
            Console.WriteLine("< Меню >");
            Console.WriteLine(" ------");
            Console.WriteLine("Выберите действие: \n\n");
            Console.WriteLine("1) Работа с автомобилями");
            Console.WriteLine("2) Работа с пользователями");
            Console.WriteLine("3) Работа с тарифам");
            Console.WriteLine("4) О программе");
            Console.WriteLine("5) Выход из программы\n");
            int select_menu = Convert.ToInt32(Console.ReadLine());
            switch (select_menu)
            {
                case 1:
                    Console.Clear();
                    Cars();
                    break;
                case 2:
                    Console.Clear();
                    Users();
                    break;
                case 3:
                    Console.Clear();
                    Tarifs();
                    break;
                case 4:
                    Console.Clear();
                    InfoProgram();
                    break;
                case 5:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        private static void Cars()
        {
            FirmCar ourFirmCar = new FirmCar() { NameFirmCar = "the Driver Car" };

            int SelectCarMenu = 0;
            do
            {
                Console.WriteLine("< Работа с автомобилями >\n");
                Console.WriteLine("Выберите действие: \n\n");
                Console.WriteLine("1) Добавить авто");
                Console.WriteLine("2) Информация об авто");
                Console.WriteLine("3) Экспорт XML");
                Console.WriteLine("4) Удалить авто");
                Console.WriteLine("5) Импорт XML");
                Console.WriteLine("6) Назад");
                SelectCarMenu = Convert.ToInt32(Console.ReadLine());
                switch (SelectCarMenu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите данные одного авто\n");
                        Car c = new Car();
                        c.ReadDataCar();
                        ourFirmCar.AddCar(c);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("ID/Марка/Модель/Цвет/Год выпуска/VIN кузова/ПТС/ОСАГО\n");
                        ourFirmCar.WriteAllCar();
                        break;
                    case 3:
                        Console.Clear();
                        XmlSerializer exportCar = new XmlSerializer(typeof(List<Car>));
                        using (FileStream CC = new FileStream("Car.xml", FileMode.OpenOrCreate))
                        {
                            exportCar.Serialize(CC, ourFirmCar.Cars);

                            Console.WriteLine("Авто экспортировалось");
                        }
                        Console.WriteLine("\n");
                        break;
                    case 4:
                        Console.Clear();
                        ourFirmCar.WriteAllCar();
                        Console.Write("Введите номер для удаления авто: ");
                        int numToDeleteCar = Convert.ToInt32(Console.ReadLine());
                        Car carToDelete = ourFirmCar.Cars[numToDeleteCar];
                        ourFirmCar.DeleteCar(carToDelete);
                        break;
                    case 5:
                        Console.Clear();
                        using (FileStream CC = new FileStream("Car.xml", FileMode.OpenOrCreate))
                        {
                            XmlSerializer inputCar = new XmlSerializer(typeof(List<Car>));
                            List<Car> newCars = (List<Car>)inputCar.Deserialize(CC);
                            ourFirmCar.Cars.AddRange(newCars);
                            Console.WriteLine("Авто импортировалось");
                            foreach (var newCar in newCars)
                            {
                                Console.WriteLine(newCar);
                            }
                            Console.WriteLine("\n");
                        }
                        break;
                }
            }
            while (SelectCarMenu != 6);
            Console.Clear();
            Menu(); //при переходе на меню, сбрасивает List Car
        }
        private static void Users()
        {
            FirmUser ourFirmUser = new FirmUser() { NameFirmUser = "the Driver User" };

            int SelectUserMenu = 0;
            do
            {
                Console.WriteLine("< Работа с пользователями >");
                Console.WriteLine("Выберите действие: \n\n");
                Console.WriteLine("1) Добавить пользователя");
                Console.WriteLine("2) Информация об пользователе");
                Console.WriteLine("3) Экспорт XML");
                Console.WriteLine("4) Удалить пользователя");
                Console.WriteLine("5) Импорт XML");
                Console.WriteLine("6) Назад");
                SelectUserMenu = Convert.ToInt32(Console.ReadLine());
                switch (SelectUserMenu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите данные одного пользователя\n");
                        User u = new User();
                        u.ReadDataUser();
                        ourFirmUser.AddUser(u);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("ID/ФИО/Возраст/Стаж вождения/Водительское удостоверение/Паспорт/Реквезиты банковской карты/Мобильный номер\n");
                        ourFirmUser.WriteAllUser();
                        break;
                    case 3:
                        Console.Clear();
                        XmlSerializer exportUser = new XmlSerializer(typeof(List<User>));
                        using (FileStream UU = new FileStream("User.xml", FileMode.OpenOrCreate))
                        {
                            exportUser.Serialize(UU, ourFirmUser.Users);

                            Console.WriteLine("Пользователи экспортировались\n");
                        }
                        Console.WriteLine("\n");
                        break;
                    case 4:
                        Console.Clear();
                        ourFirmUser.WriteAllUser();
                        Console.Write("Введите номер для удаления пользователя: ");
                        int numToDeleteUser = Convert.ToInt32(Console.ReadLine());
                        User UserToDelete = ourFirmUser.Users[numToDeleteUser];
                        ourFirmUser.DeleteUser(UserToDelete);
                        break;
                    case 5:
                        Console.Clear();
                        using (FileStream UU = new FileStream("User.xml", FileMode.OpenOrCreate))
                        {
                            XmlSerializer inputUser = new XmlSerializer(typeof(List<User>));
                            List<User> newUsers = (List<User>)inputUser.Deserialize(UU);
                            ourFirmUser.Users.AddRange(newUsers);
                            Console.WriteLine("Пользователи импортировались");
                            foreach (var newUser in newUsers)
                            {
                                Console.WriteLine(newUser);
                            }
                            Console.WriteLine("\n");
                        }
                        break;
                }
            }
            while (SelectUserMenu != 6);
            Console.Clear();
            Menu(); //при переходе на меню, сбрасивает List User
        }
        private static void Tarifs()
        {

            FirmTarif ourFirmTarif = new FirmTarif() { NameFirmTarif = "the Driver Tarif" };

            int SelectTarifMenu = 0;
            do
            {
                Console.WriteLine("< Работа с тарифами >");
                Console.WriteLine("Выберите действие: \n\n");
                Console.WriteLine("1) Добавить тарифы");
                Console.WriteLine("2) Информация об тарифах");
                Console.WriteLine("3) Экспорт XML");
                Console.WriteLine("4) Удалить тариф");
                Console.WriteLine("5) Импорт XML");
                Console.WriteLine("6) Назад");
                SelectTarifMenu = Convert.ToInt32(Console.ReadLine());
                switch (SelectTarifMenu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите данные одного тарифа\n");
                        Tarif t = new Tarif();
                        t.ReadDataTarif();
                        ourFirmTarif.AddTarif(t);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("ID/сумма тарифа (руб/час)/Описание\n");
                        ourFirmTarif.WriteAllTarif();
                        break;
                    case 3:
                        Console.Clear();
                        XmlSerializer exportTarif = new XmlSerializer(typeof(List<Tarif>));
                        using (FileStream TT = new FileStream("Tarif.xml", FileMode.OpenOrCreate))
                        {
                            exportTarif.Serialize(TT, ourFirmTarif.Tarifs);

                            Console.WriteLine("Тариф экспортировалась\n");
                        }
                        Console.WriteLine("\n");
                        break;
                    case 4:
                        Console.Clear();
                        ourFirmTarif.WriteAllTarif();
                        Console.Write("Введите номер для удаления тарифа: ");
                        int numToDeleteTarif = Convert.ToInt32(Console.ReadLine());
                        Tarif TarifToDelete = ourFirmTarif.Tarifs[numToDeleteTarif];
                        ourFirmTarif.DeleteTarif(TarifToDelete);
                        break;
                    case 5:
                        Console.Clear();
                        using (FileStream TT = new FileStream("Tarif.xml", FileMode.OpenOrCreate))
                        {
                            XmlSerializer inputTarif = new XmlSerializer(typeof(List<Tarif>));
                            List<Tarif> newTarifs = (List<Tarif>)inputTarif.Deserialize(TT);
                            ourFirmTarif.Tarifs.AddRange(newTarifs);
                            Console.WriteLine("Тариф импортировались");
                            foreach (var newTarif in newTarifs)
                            {
                                Console.WriteLine(newTarif);
                            }
                            Console.WriteLine("\n");
                        }
                        break;
                }
            }
            while (SelectTarifMenu != 6);
            Console.Clear();
            Menu(); //при переходе на меню, сбрасивает List Tarif
        }
        private static void InfoProgram()
        {
            InfoProgram infoProgram = new INFOPROGRAM();
            Console.WriteLine(infoProgram.Write());
            string go_menu = Console.ReadLine();
            switch (go_menu)
            {
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }
}
