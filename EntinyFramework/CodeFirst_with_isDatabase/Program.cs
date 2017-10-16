using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_with_isDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using(UserContext db=new UserContext())
            {
                var users = db.users;
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                }

            }

            Console.ReadKey();
        }
    }
}
