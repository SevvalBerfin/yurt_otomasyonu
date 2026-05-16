using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace yurt_otomasyon_projesi
{
    internal class StudentDbContext :DbContext
    {
        public StudentDbContext(): base("name=StudentDbContext")
        {
        }

        public DbSet<student> students { get; set; }
    }
}
