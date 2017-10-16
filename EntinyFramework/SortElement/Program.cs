using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SortElement
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Для упорядочивания полученных из бд данных по возрастанию служит метод OrderBy
             *  или оператор orderby. Например, отсортируем объекты по возрастанию по свойству Name
             * */

            using (Context db = new Context())
            {
                var phones = db.phones.OrderBy(p => p.Name);

                foreach(var phone in phones)
                {
                    Console.WriteLine("Имя: {0}\n Стоимость :{1}", phone.Name, phone.Price);
                    Console.WriteLine("----------------------------------");
                }
                

            }

            using (Context db = new Context())
            {
                /*
                 * В качестве альтернативы методу OrderBy можно использовать оператор orderby:
                 * */
                var phones = from p in db.phones
                             orderby p.Name
                             select p;
                foreach (Phone p in phones)
                    Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);
            }


            /*
             * Если нам надо отсортировать данные сразу
             *  по нескольким критериям, то мы можем
             *   применить методы ThenBy()
             *   (для сортировки по возрастанию) и 
             *   ThenByDescending().
             *    Например, отсортируем результат проекции
             *     по двум столбцам:
             * */

            //using (Context db = new Context())
            //{
            //    var phones = db.phones
            //        .Select(p => new { Name = p.Name, Price = p.Price })
            //        .OrderBy(p => p.Price)
            //        .ThenBy(p => p.Company);
            //}

                Console.ReadKey();

        }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

       
    }

    public class Context:DbContext
    {
        public Context():base("SortConnection")
        { }
        public DbSet<Phone> phones { get; set; }

    }

    class MyContextInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context db)
        {
            

            Phone p1 = new Phone { Name = "Samsung Galaxy S5", Price = 20000 };
            Phone p2 = new Phone { Name = "Samsung Galaxy S4", Price = 15000 };
            Phone p3 = new Phone { Name = "iPhone5", Price = 28000 };
            Phone p4 = new Phone { Name = "iPhone 4S", Price = 23000 };
            Phone p5 = new Phone { Name = "Samsung Galaxy S5", Price = 20000 };
            Phone p6 = new Phone { Name = "Samsung Galaxy S4", Price = 15000 };
            Phone p7 = new Phone { Name = "iPhone5", Price = 28000 };
            Phone p8 = new Phone { Name = "iPhone 4S", Price = 23000 };

            db.phones.AddRange(new List<Phone>() { p1, p2, p3, p4,p5,p6,p7,p8 });
            db.SaveChanges();
        }
    }

}
