using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.DataAccessLayer
{
    public class ContextMH : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-A7U7GT0\\SQLEXPRESS;database=CoreBlogApiDbMH;integrated security=true");
        }
        public DbSet<EmployeeMH> Employees { get; set; }
    }
}
