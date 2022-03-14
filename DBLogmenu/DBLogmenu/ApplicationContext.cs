using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLogmenu
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext()
           : base(@"Server=ADCLG1;Database=Login;Trusted_Connection=True;")
        { }
    }
}
