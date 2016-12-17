using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LokaVerkefniCL
{
    class LokaverkefniDBContext : DbContext
    {
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Zip> Zip { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
