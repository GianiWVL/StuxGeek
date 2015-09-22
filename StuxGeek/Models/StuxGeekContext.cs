using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StuxGeek.Models
{
    public class StuxGeekContext: DbContext
    {

        public StuxGeekContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StuxGeekContext, StuxGeek.Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}