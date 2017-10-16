using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace one_to_many
{
    class Context:DbContext
    {
        public Context() : base("Context") { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
