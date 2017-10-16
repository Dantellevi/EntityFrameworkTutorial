using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_many_to_Many
{
   public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public Player()
        {
            Teams = new List<Team>();

        }
    }
}
