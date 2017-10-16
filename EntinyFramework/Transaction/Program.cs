using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (UserContext db = new UserContext())
            //{
            //    using (var transaction = db.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            Person p1 = db.People.FirstOrDefault(p => p.Name == "Bob");
            //            p1.Name = "Bob Senior";
            //            db.Entry(p1).State = EntityState.Modified;
            //            Person p2 = new Person { Name = "Bob Junior", Age = 1 };
            //            db.People.Add(p2);
            //            db.SaveChanges();
            //            transaction.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            transaction.Rollback();
            //        }
            //    }

            //    foreach (Person p in db.People.ToList())
            //        Console.WriteLine("Name: {0}  Age: {1}", p.Name, p.Age);
            //}


        }
    }
}
