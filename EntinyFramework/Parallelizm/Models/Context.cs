using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Parallelizm.Models
{
    public class Context
    {
        public DbSet<Person> Persons { get; set; }
    }
}