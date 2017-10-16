using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_operation_with_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            //Добавление в базу данных
            //-------------------------------------------
            using (PhoneContext db = new PhoneContext())
            {
                //Phone[] p = new Phone[2];

                //var phones = db.Phones.ToList();
                //foreach (var pl in phones)
                //    Console.WriteLine("{0} - {1} - {2}", pl.Id, pl.Name, pl.price);

                //for (int i = 0; i < 2; i++)
                //{
                //    Console.WriteLine("Введите название:");
                //    string Nm = Console.ReadLine();
                //    //p[i].Name = Console.ReadLine();
                //    p[i] = new Phone { Name = Nm.ToString() };
                //    Console.WriteLine("Введите стоимость:");
                //    p[i] = new Phone { price = decimal.Parse(Console.ReadLine()) };

                //    db.Phones.Add(p[i]);
                //    db.SaveChanges();
                //    Console.WriteLine("{0}- элемент добавлен в базу данных:", i + 1);

                //}
                //var phoness = db.Phones.ToList();
                //foreach (var pl in phoness)
                //    Console.WriteLine("{0} - {1} - {2}", pl.Id, pl.Name, pl.price);

                Phone p1 = new Phone { Name = "Samsung Galaxy S7", price = 20000 };
                Phone p2 = new Phone { Name = "iPhone 7", price = 28000 };

                // добавление
                db.Phones.Add(p1);
                db.Phones.Add(p2);
                db.SaveChanges();   // сохранение изменений

                var phones = db.Phones.ToList();
                foreach (var p in phones)
                    Console.WriteLine("{0} - {1} - {2}", p.Id, p.Name, p.price);


               

            }

            //Редактирование базы данных
            //===========================================================
            using (PhoneContext db = new PhoneContext())
            {
                // получаем первый объект
                Phone p1 = db.Phones.FirstOrDefault();

                p1.price = 30000;
                db.SaveChanges();   // сохраняем изменения
            }

            //вторая ситуация
            //-----------------------------------------------------
            //
            /*
             * Так как объект Phone получен в одном контексте, а изменяется для другого контекста, который его не отслеживает.
             *  В итоге изменения не сохранятся. Чтобы изменения сохранились, 
             *  нам явным образом надо установить 
             *  для его состояния значение EntityState.Modified:
             * 
             * 
             * */


            //Phone p1;
            //using (PhoneContext db = new PhoneContext())
            //{
            //    p1 = db.Phones.FirstOrDefault();
            //}

            //using (PhoneContext db = new PhoneContext())
            //{
            //    if (p1 != null)
            //    {
            //        p1.Price = 60000;
            //        db.Entry(p1).State = EntityState.Modified;
            //db.SaveChanges();
            //    }
            //}

            //------------------------------------------------------

            //===========================================================

            //удаление
            using (PhoneContext db = new PhoneContext())
            {
                Phone p1 = db.Phones.FirstOrDefault();
                if (p1 != null)
                {
                    db.Phones.Remove(p1);
                    db.SaveChanges();
                }
            }

            /*
             * Но как и в случае с обновлением здесь мы можем столкнуться с похожей проблемой,
             *  когда объект получаем из базы данных в пределах одного контекста,
             *   а пытаемся удалить в другом контексте.
             *    И в этом случае нам надо установить вручную у
             *     объекта состояние EntityState.Deleted:
             * 
             * 
             * */


            //==============================================вариант 2============================================
            //using (PhoneContext db = new PhoneContext())
            //{
            //    if (p1 != null)
            //    {
            //        db.Entry(p1).State = EntityState.Deleted;
            //        db.SaveChanges();
            //    }
            //}
            //===================================================================================================

            //--------------------------------------------- Метод Attach-----------------------------------------


            //Phone p1;
            //using (PhoneContext db = new PhoneContext())
            //{
            //    p1 = db.Phones.FirstOrDefault();
            //}
            //// редактирование
            //using (PhoneContext db = new PhoneContext())
            //{
            //    if (p1 != null)
            //    {
            //        db.Phones.Attach(p1);
            //        p1.price = 999;
            //        db.SaveChanges();
            //    }
            //}
            //// удаление
            //using (PhoneContext db = new PhoneContext())
            //{
            //    if (p1 != null)
            //    {
            //        db.Phones.Attach(p1);
            //        db.Phones.Remove(p1);
            //        db.SaveChanges();
            //    }
            //}


            ////----------------------------------------------

            Console.ReadKey();
        }
    }
}
