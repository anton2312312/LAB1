using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFandEntityFramework
{
    internal class PeopleContext : DbContext
    {
        public PeopleContext() : base("MyConnection")
        {

        }
        public DbSet<Person> Person { get; set; }
    }
}
