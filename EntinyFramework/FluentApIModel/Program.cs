using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FluentApIModel
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
        public Company Company { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Phone BestSeller { get; set; }
    }


    class FluentContext : DbContext
    {
        public FluentContext() : base("FluentConnection")
        { }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }

        //Смартфон обязательно имеет производителя,
        //но производитель может не иметь наиболее продаваемого телефона.
        //То есть в данном случае связь один-к нулю или ко многим.
        //В Fluent API она устанавливается следующим образом:

        /*
         * Метод HasRequired() указывает, что для сущности Phone обязательно должно быть указано
         *  навигационное свойство Company.
         *   А метод WithOptional(), наоборот,
         *    устанавливает необязательную связь между объектом предыдущего выражения
         *     - Company и его свойством BestSeller.
         *     
         *     
         *     Метод WithRequiredPrincipal() настраивает обязательную связь
         *      и устанавливает одну из сущностей в качестве основной.
         *       Так, в данном случае основной сущность устанавливается модель 
         *       Phone: WithRequiredPrincipal(c => c.BestSeller).
         *        А таблица, на которую отображается модель Company,
         *         будет содержать внешний ключ к таблице Phones.
         * */
         //-----------------------------------------------------------------------
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>()
                .HasRequired(c => c.Company)
                .WithOptional(c => c.BestSeller);

            base.OnModelCreating(modelBuilder);
        }

        //--------------------------------------------------------------------------

        //многие ко многим
        /*
         * Пусть у нас есть ситуация,
         *  когда любая из моделей содержит список объектов другой модели.
         *   Например, компания может производить несколько телефонов,
         *    а над одним телефоном могут работать несколько компаний:
         * 
         * public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; }
     
    public ICollection<Company> Companies { get; set; }
 
    public Phone()
    {
        Companies = new List<Company>();
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

Тогда настройка связи между ними будет выглядеть следующим образом:
HasMany() устанавливает множественную связь между объектом Phone и объектами Company.
А метод WithMany() добавляет обратную множественную связь между объектом Company и объектами Phone.
 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Phone>()
    .HasMany(p => p.Companies)
    .WithMany(c => c.Phones);

            base.OnModelCreating(modelBuilder);
        }

         *
         *Но нас может не устраивать подобное название таблицы и ее столбцов,
         *  и мы можем стандартное поведение переопределить следующим образом:
         *
         * modelBuilder.Entity<Phone>()
    .HasMany(p => p.Companies)
    .WithMany(c => c.Phones)
    .Map(m =>
    {
        m.ToTable("MobileCompanies");
        m.MapLeftKey("MobileId");
        m.MapRightKey("CompanyId");
    }); ;
    //--------------------------------------------------------------------
        Связь один-ко-многим (One-to-Many)

При связи один-ко-многим одна модель может ссылаться на множество объектов другой модели.
Например, одна компания производит множество телефонов:
public class Phone
{
    public int Id { get; set; }
    public string Name { get; set; }
 
    public Company Company { get; set; }
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
    .HasMany(p => p.Phones)
    .WithRequired(p=>p.Company);

            base.OnModelCreating(modelBuilder);
        }

        //------------------------------------------------------------------------


         * 
         * */




    }

}
