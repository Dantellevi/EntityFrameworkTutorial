using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// <summary>
/// Как из базы данных делать модели для проекта
/// создаем ADO.Net Entity DAta Model
/// Code First From DataBase
/// 
/// </summary>
namespace automatizationCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            using (UserContext db = new UserContext())
            {
                foreach(var us in db.Users)
                {
                    Console.WriteLine("Индификационный номер: {0}", us.Id);
                    Console.WriteLine("Имя :" + us.Name);
                    Console.WriteLine("Возраст: " + us.Age.ToString());

                }
            }

            Console.ReadKey();

        }
    }
}
