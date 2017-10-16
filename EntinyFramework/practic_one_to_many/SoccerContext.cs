using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace practic_one_to_many
{
   public class SoccerContext:DbContext
    {

        public SoccerContext() : base("PracticSoccerDB") { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }


    }
}
