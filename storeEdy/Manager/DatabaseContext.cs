using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using storeEdy.Models;

namespace storeEdy.Manager
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("DBStoreEdy"){ }

        public DbSet<NewUrunler> Urunler { get; set; }

        public DbSet<NewFisler> Fisler { get; set; }


        public DbSet<Sepet> Sepetler { get; set; }

        public DbSet<SepetOturum> SepetOturumlar { get; set; }
    }
}