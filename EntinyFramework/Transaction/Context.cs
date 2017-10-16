using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Transaction
{
    public class Context:DbContext
    {

        public Context() : base("Tranzaction") { }

        public DbSet<Man> Peaple { get; set; }

    }
}
