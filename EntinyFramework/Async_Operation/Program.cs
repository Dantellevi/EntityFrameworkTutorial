using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Async_Operation
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем новый объект
            Phone p = new Phone { Name = "Nokia Lumia 930", Price = 13000 };
            //запуск метода сохранение с ожиданием
            SaveObjectsAsync(p).Wait();
            //передаем данные в ассинхронный поток из метода
            Task t = GetObjectsAsync();
            //выполняем операцию
            t.Wait();

            Console.Read();
        }

        //извлечение элементов из базы данных
        public static async Task GetObjectsAsync()
        {
            using (PhoneCotext db = new PhoneCotext())
            {
                await db.phones.ForEachAsync(p =>
                {
                    Console.WriteLine("{0} ({1})", p.Name, p.Price);
                });
            }
        }

        //добавление элемента в базу данных
        private static async Task SaveObjectsAsync(Phone p)
        {
            using (PhoneCotext db = new PhoneCotext())
            {
                db.phones.Add(p);
                await db.SaveChangesAsync();
            }
        }

        //SQL Commands
        private static async Task DbCommandAsync(Phone p)
        {
            using (PhoneCotext db = new PhoneCotext())
            {
                System.Data.SqlClient.SqlParameter name = new System.Data.SqlClient.SqlParameter("name", p.Name);
                System.Data.SqlClient.SqlParameter price = new System.Data.SqlClient.SqlParameter("price", p.Price);
                await db.Database.ExecuteSqlCommandAsync("INSERT INTO Phones (Name, Price) VALUES (@name, @price)", name, price);
            }
        }
    }


    public class Phone
    {
        public int Ident { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
       
    }

    public class PhoneCotext:DbContext
    {
        public DbSet<Phone> phones { get; set; }

    }

}
