using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() :base("WebApiDbConnection")
        {

        }

        public DbSet<Kullanici>Kullanicilar { get; set; }
    }
}