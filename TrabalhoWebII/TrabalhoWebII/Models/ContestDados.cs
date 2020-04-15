using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrabalhoWebII.Models
{
    public class ContestDados: DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Spcserasa> Spcserasas { get; set; }

    }
}