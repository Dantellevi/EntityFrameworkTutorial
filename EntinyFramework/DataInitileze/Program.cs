using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataInitileze
{

    /*
     * Для инициализации мы можем использовать один из классов инициализаторов, 
     * которые имеются в библиотеке .NET:

        CreateDatabaseIfNotExists: инициализатор, используемый по умолчанию. 
        Он не удаляет автоматчески базу данных и данные, а в случае изменения структуры моделей
        и контекста данных выбрасывает исключение.

        DropCreateDatabaseIfModelChanges: данный инициализатор проверяет на соответствие
        моделям определения таблиц в базе данных. И если модели не соответствуют определению таблиц
        , то база данные пересоздается

        DropCreateDatabaseAlways:
        этот инициализатор будет всегда пересоздавать базу данных.
     * 
     * 
     * 
     * */



    class Program
    {
        static void Main(string[] args)
        {

            using (MobileContext db = new MobileContext())
            {

                foreach(var item in db.Phones)
                {
                    Console.WriteLine("Марка= {0}", item.Name);
                    Console.WriteLine("Стоимость ={0}", item.Price);
                    Console.WriteLine("---------------------------------------");
                }

                Console.ReadKey();


            }

        }
    }

    //класс начальной инициализации БД
    class MyContextInitializer : DropCreateDatabaseAlways<MobileContext>
    {
        protected override void Seed(MobileContext db)
        {
            Phone p1 = new Phone { Name = "Samsung Galaxy S5", Price = 14000 };
            Phone p2 = new Phone { Name = "Nokia Lumia 630", Price = 8000 };

            db.Phones.Add(p1);
            db.Phones.Add(p2);
            db.SaveChanges();
        }
    }


    //Модель
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }


    //Контекст данных
    class MobileContext : DbContext
    {
        static MobileContext()
        {
            Database.SetInitializer<MobileContext>(new MyContextInitializer());//запуск инициализатора в конструкторе контекста данных
        }

        public MobileContext() : base("InitilizeConnection")
        { }
        public DbSet<Phone> Phones { get; set; }
    }


}
