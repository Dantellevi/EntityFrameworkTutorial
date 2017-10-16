using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_First
{
    class Program
    {
        static void Main(string[] args)
        {
            using (userstoredbsEntities db = new userstoredbsEntities())
                {
                var users = db.Users;
                foreach ( var u in users)
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
            }

        }
    }
}
