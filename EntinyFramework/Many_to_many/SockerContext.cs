using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Many_to_many
{
   public class SockerContext:DbContext
    {

        public SockerContext() : base("ManyToManyS") { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }


    }
}
