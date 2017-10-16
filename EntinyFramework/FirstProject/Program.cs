using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {

            using (UserContext db = new UserContext())
            {

                //создаем два объекта User
                User user1 = new User { Name = "Alex", Age = 23 };
                User user2 = new User { Name = "Alexei", Age = 22 };

                db.users.Add(user1);
                db.users.Add(user2);

                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены!!!");
                //--------------------------------------------------------------

                //получаем объекты из базы данных

                var Users = db.users;

                //Выводим данные по объектам

                Console.WriteLine("Объекты из базы данных :");

                foreach(var User in Users)
                {
                    Console.WriteLine("Имя пользователя : " + User.Name + " Возраст: {0}", User.Age);
                }

                Console.ReadKey();


            }

            

        }
    }
}
