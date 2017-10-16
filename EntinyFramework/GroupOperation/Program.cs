using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GroupOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Чтобы сгруппировать данные по определенным параметрам используются оператор group by
             * или метод GroupBy(). Например, сгруппируем модели телефонов по производителю
             * */

            using (Context db = new Context())
            {
                var groups = from p in db.phones
                             group p by p.Company.Name;
                foreach (var g in groups)
                {
                    Console.WriteLine(g.Key);
                    foreach (var p in g)
                        Console.WriteLine("{0} - {1}", p.Name, p.Price);
                    Console.WriteLine();
                }


                // альтернативный способ
                //var groups = db.Phones.GroupBy(p=>p.Company.Name)
                //                  .Select(g => new { Name = g.Key, Count = g.Count()});
                //foreach (var c in groups)
                //    Console.WriteLine("Производитель: {0} Кол-во моделей: {1}", c.Name, c.Count);
            }
        }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Comapany Company { get; set; }
        public ICollection<Comapany> Companys { get; set; }

    }
    public class Comapany
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Context : DbContext
    {
        public Context() : base("SortConnection")
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

            db.phones.AddRange(new List<Phone>() { p1, p2, p3, p4, p5, p6, p7, p8 });
            db.SaveChanges();
        }
    }

}
