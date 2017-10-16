using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                foreach(var p in db.Phones)
                {
                    Console.WriteLine("Name:" + p.Name);
                }
            }

            Console.ReadKey();

        }
    }

    public class PhoneContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public PhoneContext() : base("MigrationConnection")
        { }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Company { get; set; }
    }
}
