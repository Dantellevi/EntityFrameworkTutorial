using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Practic1_Work_Crud
{
     class PlayerContext:DbContext
    {

        public PlayerContext() : base("DefaultConnection") { }
        public DbSet<Player> Players { get; set; }


    }
}
