using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCCodeFirst.Models;

namespace MVCCodeFirst.Context
{
    public class SaldemContext : DbContext
    {
        public DbSet<Afet> Afet { get; set; }
        public DbSet<AfetTur> AfetTur { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<AfetResim> AfetResim { get; set; }

    }
}