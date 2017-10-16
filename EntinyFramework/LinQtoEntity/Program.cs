using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LinQtoEntity
{
    class Program
    {
        static void Main(string[] args)
        {

            //Операторы языка LINQ
            //-----------------------------------------------
            using (PhoneContext db = new PhoneContext())
            {
                var phones = from p in db.Phones
                             where p.CompanyId == 1
                             select p;
            }
            //------------------------------------------------

            //запрос с помощью метода расширений LINQ
            //------------------------------------------------------
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.CompanyId == 1);

            }
            //-----------------------------------------------------

            //Важно понимать различие между Linq to Entities и Linq to Objects:
            //var phones = db.Phones.Where(p=> p.CompanyId == 1).ToList().Where(p=> p.Id<10);

            //Здесь используются два метода Where, но их реализация будет различной.
            //В первом случае, db.Phones.Where(p => p.CompanyId == 1) транслируется
            //в выражение SQL, которое было рассмотрено выше.Далее метод ToList() 
            //по результатам запроса создает список в памяти компьютера. После этого мы 
            //уже имеем дело со списком в памяти, а не с базой данных. И далее вызов 
            //Where(p => p.Id < 10) будет обращаться к списку в памяти и будет представлять
            //Linq to Object.





        }
    }


    //модель один-ко-многим(one Company and Many Phone)

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
