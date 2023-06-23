using Microsoft.EntityFrameworkCore;
using System;

namespace Practical18_Core.Models
{
    public class EmpContext:DbContext
    {


        public EmpContext(DbContextOptions<EmpContext> options) : base(options){  }

        public DbSet<Employee> employees { get; set; }  
    }
}
