using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many_to_many
{
  public  class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        public ICollection<Team> Teams { get; set; }
        public Player()
        {
            Teams = new List<Team>();
        }

    }
}
