using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Domain_Rest_Api
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext()
        {

        }

        public DbSet<Domain> Domains { get; set; }
    }
}
