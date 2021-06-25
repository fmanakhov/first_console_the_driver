using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_Driver
{
    [Serializable]
    public class FirmUser
    {
        public string NameFirmUser { get; set; }

        public List<User> Users { get; set; }

        public FirmUser()
        {
            Users = new List<User>();
        }
        public void WriteAllUser()
        {
            for (int ii = 0; ii < Users.Count; ii++)
            {
                Console.WriteLine(ii + ". " + Users[ii]);
            }
            Console.WriteLine("\n");
        }
        public void AddUser(User u)
        {
            Users.Add(u);
            Console.WriteLine("\n");
        }
        public void DeleteUser(User u)
        {
            Users.Remove(u);
            Console.WriteLine("\n");
        }
    }
}
