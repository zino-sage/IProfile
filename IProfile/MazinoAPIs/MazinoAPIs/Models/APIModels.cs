using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MazinoAPIs.Models
{
    public class APIModels : DbContext
    {

        public APIModels() : base("name=APIModels")
        {
            Database.SetInitializer<APIModels>(null);
            Database.CommandTimeout = 300;
        }

        public DbSet<ACCOUNTS_TBL> ACCOUNTS_TBL{ get; set; }
        public DbSet<USERS_TBL> USERS_TBL { get; set; }
    }
}
