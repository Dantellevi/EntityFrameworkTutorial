using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SelectinDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            //Для выборки применяется метод Where.
            //Выберем из бд все модели, производитель которых - "Samsung":
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.Company.Name == "Samsung");
                foreach (Phone p in phones)
                    Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);

                //Для выборки одного объекта мы можем использовать метод Find().
                //Данный метод не является методом Linq, он определен у класса DbSet:

        //---------------------------------------------------------------------------

                var ph = db.Phones.Find(3);

                /*
                 * Но в качестве альтернативы мы можем использовать методы
                 *  Linq First()/FirstOrDefault(). Они получают первый элемент выборки,
                 *   который соответствует определенному условию.
                 *    Использование метода FirstOrDefault() является более гибким,
                 *     так как если выборка пуста, то он вернет значение null.
                 *      А метод First() в той же ситуации выбросит ошибку.
                 * 
                 * */

                Phone myPhone = db.Phones.FirstOrDefault(p => p.Id == 3);
                if (myPhone != null)
                    Console.WriteLine(myPhone.Name);

            //----------------------------------------------------------------------


            }


            /*
             * Теперь сделаем проекцию. Допустим, нам надо добавить в результат выборки
             *  название компании. Мы можем использовать метод Include для подсоединения
             *  к объекту связанных данных из другой таблицы:
             *  var phones = db.Phones.Include(p=>p.Company).
             *  Но не всегда нужны все свойства выбираемых объектов.
             *  В этом случае мы можем применить метод Select для проекции извлеченных
             *  данных на новый тип:
             * 
             * */

            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Select(p => new
                {
                    Name=p.Name,
                    Price=p.Price,
                    Company=p.Company.Name
                });
                foreach (var p in phones)
                    Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);
            }
        }
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Phone> Phones { get; set; }
        public Company()
        {
            Phones = new List<Phone>();
        }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }


    //создание контекста
    class PhoneContext : DbContext
    {
        static PhoneContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
        public PhoneContext() : base("LinQConnection")
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }

    //первичная инициализация
    class MyContextInitializer : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext db)
        {
            Company c1 = new Company { Name = "Samsung" };
            Company c2 = new Company { Name = "Apple" };
            db.Companies.Add(c1);
            db.Companies.Add(c2);

            db.SaveChanges();

            Phone p1 = new Phone { Name = "Samsung Galaxy S5", Price = 20000, Company = c1 };
            Phone p2 = new Phone { Name = "Samsung Galaxy S4", Price = 15000, Company = c1 };
            Phone p3 = new Phone { Name = "iPhone5", Price = 28000, Company = c2 };
            Phone p4 = new Phone { Name = "iPhone 4S", Price = 23000, Company = c2 };

            db.Phones.AddRange(new List<Phone>() { p1, p2, p3, p4 });
            db.SaveChanges();
        }
    }
}
