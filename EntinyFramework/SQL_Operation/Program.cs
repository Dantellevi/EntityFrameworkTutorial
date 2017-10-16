using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SQL_Operation
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Для осуществления прямых sql-запросов к базе данных можно воспользоваться свойством Database,
             * которое имеется у класса контекста данных.
             * Данное свойство позволяет получать информацию о базе данных,
             * подключении и осуществлять запросы к БД. Например, получим строку подключения
             * */
            using (Context db = new Context())
            {
                Console.WriteLine(db.Database.Connection.ConnectionString);

                //получим все модели из таблицы Companies:
                //var comps = db.Database.SqlQuery<Comapany>("SELECT * FROM Companies");
                //foreach (var company in comps)
                //    Console.WriteLine(company.Name);
                var comps = db.Database.SqlQuery<Comapany>("SELECT * FROM Companies");
                foreach(var comp in comps)
                {
                    Console.WriteLine(comp.Name);
                }


                //Другая версия метода SqlQuery() позволяет использовать параметры.
                //Класс SqlParameter из пространства имен System.Data.SqlClient позволяет задать параметр, который затем передается в запрос sql.
                //Например, выберем из бд все модели, которые в названии имеют подстроку "Samsung":
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "%Samsung%");
                var phones = db.Database.SqlQuery<Phone>("SELECT * FROM phones WHERE Name LIKE @name", param);
                foreach (var phone in phones)
                    Console.WriteLine(phone.Name);

                /*
                 * Метод SqlQuery() осуществляет выборку из БД,
                 *  но кроме выборки нам, возможно, придется удалять,
                 *   обновлять уже существующие или вставлять новые записи.
                 *    Для этой цели применяется метод ExecuteSqlCommand(),
                 *     который возвращает количество затронутых командой строк:
                 * 
                 * */
                //вставка
                int numberofRowInserted = db.Database.ExecuteSqlCommand("INSERT INTO Companies (Name) VALUES ('HTC')");
                // обновление
                int numberOfRowUpdated = db.Database.ExecuteSqlCommand("UPDATE Companies SET Name='Nokia' WHERE Id=3");
                // удаление
                int numberOfRowDeleted = db.Database.ExecuteSqlCommand("DELETE FROM Companies WHERE Id=3");

            }

            Console.ReadKey();

        }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }
        public Comapany Company { get; set; }

    }
    public class Comapany
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Phone> Phones { get; set; }
        public Comapany()
        {
            Phones = new List<Phone>();
        }
    }

    public class Context : DbContext
    {
        public Context() : base("SqlOperation")
        { }
        public DbSet<Phone> phones { get; set; }
        public DbSet<Comapany> Companies { get; set; }

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
