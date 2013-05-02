using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GetIntoBreezeJS.Models
{
    public class GetIntoBreezeContext: DbContext
    {
        // Just for the sample: initialize the database
        static GetIntoBreezeContext()
        {
            Database.SetInitializer(new GetIntoBreezeInitializer());
        }    
        public DbSet<City> Cities { get; set; }
    }
}