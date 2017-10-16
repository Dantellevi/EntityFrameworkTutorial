using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Union_except_interselect
{
    class Program
    {
        static void Main(string[] args)
        {
            //Для объединения двух выборок используется метод Union():
            using (Context db = new Context())
            {
                var phones = db.phones.Where(p => p.Price < 25000)
                    .Union(db.phones.Where(p => p.Name.Contains("Samsung")));
                foreach (var item in phones)
                    Console.WriteLine(item.Name);
            }

            //---------------------------------------------------------------
            //Чтобы найти пересечение выборок, то есть те элементы,
            //которые присутствуют сразу в двух выборках, используется метод Intersect():
            using (Context db = new Context())
            {
                var phones = db.phones.Where(p => p.Price < 25000)
                    .Intersect(db.phones.Where(p => p.Name.Contains("Samsung")));
                foreach (var item in phones)
                    Console.WriteLine(item.Name);
            }
            //-------------------------------------------------------------------------
            //Если нам надо найти элементы первой выборки, которые отсутствуют во второй выборке,
            //то мы можем использовать метод Except:
            using (Context db = new Context())
            {
                var selector1 = db.phones.Where(p => p.Price < 25000); // Samsung Galaxy S4, Samsung Galaxy S4, iPhone S4
                var selector2 = db.phones.Where(p => p.Name.Contains("Samsung")); // Samsung Galaxy S4, Samsung Galaxy S4
                var phones = selector1.Except(selector2); // результат -  iPhone S4

                foreach (var item in phones)
                    Console.WriteLine(item.Name);
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
