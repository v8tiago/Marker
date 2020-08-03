using Marker.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marker.Data.Mappings
{
    class ReuniaoMapping : IEntityTypeConfiguration<Reuniao>
    {
        public void Configure (EntityTypeBuilder<Reuniao> builder)
        {
            builder.HasKey( p => p.Id );
            builder.Property( p => p.Assunto )
                .IsRequired()
                .HasColumnType( "varchar(250)" );

            builder.ToTable( "Reunioes" );
        }
    }
}
