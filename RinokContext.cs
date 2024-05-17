using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rinok
{
    public class RinokContext : DbContext
    {
        public RinokContext() : base("DbConnection") { }
        public DbSet<Rinok> Rinoks { get; set; }
    }
}
