using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Many_to_many
{
    class Program
    {
        static void Main(string[] args)
        {

            //-------------------------------------------------------------------
            using (SockerContext db = new SockerContext())
            {
                //Создание и довавление моделей(игроков)
                Player pl1 = new Player { Name = "Роналду", Age = 31, Position = "Нападающий" };
                Player pl2 = new Player { Name = "Месси", Age = 28, Position = "Нападающий" };
                Player pl3 = new Player { Name = "Хави", Age = 34, Position = "Полузащитник" };
                db.Players.AddRange(new List<Player> { pl1, pl2, pl3 });
                db.SaveChanges();

                //Создание и довавление моделей(команд)
                Team t1 = new Team { Name = "Барса" };
                //добавляем созданную модель к модели игрока
                t1.Players.Add(pl2);
                t1.Players.Add(pl3);
                Team t2 = new Team { Name = "Реал Мадрид" };
                t2.Players.Add(pl1);
                db.Teams.Add(t1);
                db.Teams.Add(t2);
                db.SaveChanges();

                //выборка данных из модели Team
                foreach(Team t in db.Teams.Include(t=>t.Players))
                {
                    Console.WriteLine("Команда {0}", t.Name);

                    foreach(Player pl in t.Players)
                    {
                        Console.WriteLine("Игрок {0}------Возраст:{1}", pl.Name, pl.Age);

                    }
                }
                Console.WriteLine("------------------------------------");
                // удаляем связи с одним объектом
                Player pl_edit = db.Players.First(p => p.Name == "Месси");
                Team t_edit = pl_edit.Teams.First(p => p.Name == "Барса!!!");
                t_edit.Players.Remove(pl_edit);

                //выборка данных из модели Team
                foreach (Team t in db.Teams.Include(t => t.Players))
                {
                    Console.WriteLine("Команда {0}", t.Name);

                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("Игрок {0}------Возраст:{1}", pl.Name, pl.Age);

                    }
                }
                Console.WriteLine("------------------------------------");
                Player pl_delete = db.Players.First(p => p.Name == "Месси");
                db.Players.Remove(pl_delete);



                //выборка данных из модели Team
                foreach (Team t in db.Teams.Include(t => t.Players))
                {
                    Console.WriteLine("Команда {0}", t.Name);

                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("Игрок {0}------Возраст:{1}", pl.Name, pl.Age);

                    }
                }
                Console.WriteLine("------------------------------------");
                Console.ReadKey();

                //---------------------------------------------------------------------

            }
        }
    }
}
