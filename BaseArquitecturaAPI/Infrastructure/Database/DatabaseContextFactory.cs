using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Database
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            //just in migration moments, can be deleted then
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            /*optionsBuilder.UseSqlServer("Server = DESKTOP-BKFVL1D; Database = votationDb; trusted_connection = true");*/

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
