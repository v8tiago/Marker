using Marker.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marker.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Sala> Salas { get; set; }
        public DbSet<Reuniao> Reunioes { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly( typeof( MeuDbContext ).Assembly );

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany( e => e.GetForeignKeys() )) 
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating( modelBuilder );
        }
    }
}
