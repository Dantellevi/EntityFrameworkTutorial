using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Work_operation_with_Data
{
    public class PhoneContext:DbContext
    {
        public PhoneContext() : base("DefaultConnection") { }

        public DbSet<Phone> Phones { get; set; }


    }
}
