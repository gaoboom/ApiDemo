using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ApiDemoDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApiDemoDbContext():base("ApiDemoConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApiDemoDbContext>());
        }
    }
}