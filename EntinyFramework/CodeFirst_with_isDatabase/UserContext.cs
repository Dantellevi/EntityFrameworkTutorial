using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CodeFirst_with_isDatabase
{
  class UserContext:DbContext
    {

        public UserContext() : base("UserDB") { }


        public DbSet<User> users { get; set; }

    }
}
