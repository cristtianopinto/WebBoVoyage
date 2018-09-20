using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebBoVoyage.Models;
namespace WebBoVoyage.Data
{
    public class BoVoyageDbContext : DbContext
    {
        public BoVoyageDbContext() : base("BoVoyageConnectionString")
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<AgenceVoyage> AgenceVoyages { get; set; }

    }
}