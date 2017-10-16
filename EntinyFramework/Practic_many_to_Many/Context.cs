using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Practic_many_to_Many
{
    class Context:DbContext
    {
        public Context() : base("SocContext") { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
