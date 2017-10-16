using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace one_to_many
{
    class Program
    {
        static void Main(string[] args)
        {
            //Добавление
            //------------------------------------------------------------------------------------------
            using (Context db = new Context())
            {
                // создание и добавление моделей
                Team t1 = new Team { Name = "Барселона" };
                Team t2 = new Team { Name = "Реал Мадрид" };
                db.Teams.Add(t1);
                db.Teams.Add(t2);
                db.SaveChanges();
                Player pl1 = new Player { Name = "Роналду", Age = 31, Position = "Нападающий", Team = t2 };
                Player pl2 = new Player { Name = "Месси", Age = 28, Position = "Нападающий", Team = t1 };
                Player pl3 = new Player { Name = "Хави", Age = 34, Position = "Полузащитник", Team = t1 };
                db.Players.AddRange(new List<Player> { pl1, pl2, pl3 });
                db.SaveChanges();

                // вывод 

                foreach (Player pl in db.Players.Include(p => p.Team).ToList())
                    Console.WriteLine("{0} - {1}", pl.Name, pl.Team != null ? pl.Team.Name : "");
                Console.WriteLine();
                foreach (Team t in db.Teams.Include(t => t.Players).ToList())
                {
                    Console.WriteLine("Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                    }

                }
                Console.WriteLine();

                //редактирование
                //----------------------------------------------------------------------
                t2.Name = "Реал М."; // изменим название
                db.Entry(t2).State = EntityState.Modified;
                // переведем игрока из одной команды в другую
                pl3.Team = t2;
                db.Entry(pl3).State = EntityState.Modified;
                db.SaveChanges();
                //--------------------------------------------------------------------
                // вывод 

                foreach (Player pl in db.Players.Include(p => p.Team).ToList())
                    Console.WriteLine("{0} - {1}", pl.Name, pl.Team != null ? pl.Team.Name : "");
                Console.WriteLine();
                foreach (Team t in db.Teams.Include(t => t.Players).ToList())
                {
                    Console.WriteLine("Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                    }

                }


                //удаление игрока
                //-------------------------------------------------------------------
                Player pl_toDelete = db.Players.First(p => p.Name == "Роналду");
                db.Players.Remove(pl_toDelete);
                // удаление команды     
                Team t_toDelete = db.Teams.First();
                db.Teams.Remove(t_toDelete);
                db.SaveChanges();
                //--------------------------------------------------------------------
                foreach (Player pl in db.Players.Include(p => p.Team).ToList())
                    Console.WriteLine("{0} - {1}", pl.Name, pl.Team != null ? pl.Team.Name : "");
                Console.WriteLine();
                foreach (Team t in db.Teams.Include(t => t.Players).ToList())
                {
                    Console.WriteLine("Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                    }

                }
                Console.ReadKey();
            }

            //------------------------------------------------------------------------------------------


        }
    }
}
