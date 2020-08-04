using Marker.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marker.Data.Mappings
{
    public class SalaMapping : IEntityTypeConfiguration<Sala>
    {
        public void Configure (EntityTypeBuilder<Sala> builder)
        {
            builder.HasKey( p => p.Id );
            builder.Property( p => p.Nome )
                .IsRequired()
                .HasColumnType( "varchar(100)" );

            builder.HasMany( s => s.Reunioes )
                    .WithOne( r => r.Sala )
                    .HasForeignKey( r => r.SalaId );

            builder.ToTable( "Salas" );
        }
    }


}
