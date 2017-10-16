using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Join_Table
{
    //соединение таблиц
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Для объединения таблиц по определенному критерию используется метод Join.
             *  Например, в нашем случае таблица телефонов и таблица компаний имеет общий критерий - id компании,
             *   по которому можно провести объединение таблиц:
             * */

            using (PhoneContext db = new PhoneContext())
            {
                /*
                 * Метод Join принимает четыре параметра:

                        -вторую таблицу, которая соединяется с текущей

                        -свойство объекта - столбец из первой таблицы, по которому идет соединение

                        -свойство объекта - столбец из второй таблицы, по которому идет соединение

                        -новый объект, который получается в результате соединения
                 * */

                var phones = db.Phones.Join(db.Companies,// второй набор
                    p => p.CompanyId,// свойство-селектор объекта из первого набора
                    c => c.Id,// свойство-селектор объекта из второго набора
                    (p, c) => new // результат
                    {
                        Name = p.Name,
                        Company = c.Name,
                        Price = p.Price
                    });

                foreach (var p in phones)
                    Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);


            }


            /*
             * Соединение трех таблиц

                Допустим, у нас есть три таблицы, которые связаны между собой и которые описываются следующими моделями:
             * 
             * public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
}
public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
 
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}

            Объединим три таблицы в один набор:
            var result = from phone in db.Phones
             join company in db.Companies on phone.CompanyId equals company.Id
             join country in db.Countries on company.CountryId equals country.Id
             select new
             { 
                Name = phone.Name, 
                Company = company.Name, 
                Price = phone.Price, 
                Country = country.Name 
             };
             * */



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
        public PhoneContext() : base("JoinTable")
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
