using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Agregat_operation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Метод Count() позволяет найти количество элементов в выборке:
            using (Context db = new Context())
            {
                int number1 = db.phones.Count();
                // найдем кол-во моделей, которые в названии содержат Samsung
                int number2 = db.phones.Count(p => p.Name.Contains("Samsung"));

                Console.WriteLine(number1);
                Console.WriteLine(number2);
            }
            //-------------------------------------------------------------------
            //Для нахождения минимального, максимального и среднего значений по выборке применяются
            //функции Min(), Max() и Average() соответственно.
            //Найдем минимальную, максимальную и среднюю цену по моделям:
            using (Context db = new Context())
            {
                // минимальная цена
                int minPrice = db.phones.Min(p => p.Price);
                // максимальная цена
                int maxPrice = db.phones.Max(p => p.Price);
                // средняя цена на телефоны фирмы Samsung
                double avgPrice = db.phones.Where(p => p.Company.Name == "Samsung")
                                    .Average(p => p.Price);

                Console.WriteLine(minPrice);
                Console.WriteLine(maxPrice);
                Console.WriteLine(avgPrice);
            }
            //----------------------------------------------------------
            //Для получения суммы значений используется метод Sum():
            using (Context db = new Context())
            {
                // суммарная цена всех моделей
                int sum1 = db.phones.Sum(p => p.Price);
                // суммарная цена всех моделей фирмы Samsung
                int sum2 = db.phones.Where(p => p.Name.Contains("Samsung"))
                                    .Sum(p => p.Price);
                Console.WriteLine(sum1);
                Console.WriteLine(sum2);
            }
            //------------------------------------------------------------

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
