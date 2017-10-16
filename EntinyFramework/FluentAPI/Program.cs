using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FluentAPI
{

    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class Phone
    {
        public int Ident { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public int Price { get; set; }
    }


    class FluentContext : DbContext
    {
        public FluentContext() : base("FluentConnection")
        { }

        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            /*Сопоставление свойств

            Чтобы сопоставить свойство
            с определенным столбцом,
            используется метод HasColumnName():
             *В данном случае свойство Name будет сопоставляться со столбцом PhoneName. 
             * */
            modelBuilder.Entity<Phone>().Property(p => p.Name).HasColumnName("PhoneName");

            //Если мы не хотим, чтобы с каким-то свойством вообще шло сопоставление,
            //то мы можем его исключить с помощью метода Ignore():
            modelBuilder.Entity<Phone>().Ignore(p => p.Discount);
            /*
             * Столбцы в таблице в БД могут допускать значение NULL,
             *  которое указывает, что значение не определено.
             *   По умолчанию все столбцы при Code First,
             *    если не применяются аннотации данных,
             *     за исключением идентификатора допускают значение NULL.
             *      Но мы можем указать с помощью метода IsRequired(),
             *       что значение для этого столбца и свойства требуется обязательно:
                modelBuilder.Entity<Phone>().Property(p => p.Name).IsRequired();
                Если нам, наоборот, надо указать,
                чтобы столбец мог принимать значения NULL,
                то мы можем использовать метод IsOptional():
                modelBuilder.Entity<Phone>().Property(p => p.Name).IsOptional();
             * */


            /*
             * Настройка строк

                Для строк мы модем указать максимальную длину
                с помощью метода HasMaxLength().
                Например, длина не более 50 символов:
             * */
            modelBuilder.Entity<Phone>().Property(p => p.Name).HasMaxLength(50);

            //Также для строк можно определить, будут ли они храниться в кодировке Unicode:
            modelBuilder.Entity<Phone>().Property(p => p.Name).IsUnicode(false);


            /*
             * Настройка чисел decimal

              Если у нас есть свойство с типом decimal,
              то мы можем указать для него точность число цифр
              в числе и число цифр после запятой:
             * */
            // допустим, свойство Price - decimal
            //modelBuilder.Entity<Phone>().Property(p => p.Price).HasPrecision(15, 2);

            /*
             * Настройка типа столбцов

                По умолчанию EF сам выбирает тип данных в бд,
                исходя из типа данных свойства.
                Но мы также можем явно указать,
                какой тип данных в БД должен использоваться для столбца с помощью метода HasColumnType():
             * */
            modelBuilder.Entity<Phone>().Property(p => p.Name).HasColumnType("varchar");

            /*
             * Сопоставление модели с несколькими таблицами

                С помощью Fluent API мы можем поместить ряд
                свойств модели в одну таблицу, а другие свойства
                связать со столбцами из другой таблицы:
                Таким образом, данные для свойства Name
                будут храниться в таблице Mobiles,
                а данные для свойств Price и Discount
                - в таблице MobilesInfo.
                И столбец идентификатора будет общим.
             * */

            modelBuilder.Entity<Phone>().Map(m =>
            {
                m.Properties(p => new { p.Ident, p.Name });
                m.ToTable("Mobiles");
            })
.Map(m =>
{
    m.Properties(p => new { p.Ident, p.Price, p.Discount });
    m.ToTable("MobilesInfo");
});

            /*
              
             * Переопределение первичного ключа

                По умолчанию в Entity Framework первичный ключ
                должен представлять свойство модели с именем Id
                или [Имя_класса]Id, например, PhoneId. Чтобы
                переопределить первичный ключ через Fluent API,
                надо использовать метод HasKey():

             * */
            modelBuilder.Entity<Phone>().HasKey(p => p.Ident);
            //Чтобы настроить составной первичный ключ, мы можем указать два свойства:
            modelBuilder.Entity<Phone>().HasKey(p => new { p.Ident, p.Name });
            //сопоставления класса с таблицей(вместо Phones-Mobiles)
            modelBuilder.Entity<Phone>().ToTable("Mobiles");
            //Если по какой-то сущности нам не надо создавать таблицу, то мы можем ее проигнорировать с помощью метода Ignore():
            //modelBuilder.Ignore<Company>();
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }


}
