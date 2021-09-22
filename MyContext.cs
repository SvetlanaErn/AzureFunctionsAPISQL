using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsAPISQL
{
    public class MyContext : DbContext
    {
        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=serverse.database.windows.net,1433;Database=db;User ID=***;Password=***");
        }
    }
}
