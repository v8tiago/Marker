using Marker.Business.Interfaces;
using Marker.Business.Models;
using Marker.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marker.Data.Repository
{
    public class SalaRepository : Repository<Sala>, ISalaRepository
    {
        public SalaRepository (MeuDbContext context) : base(context) {}
        public async Task<Sala> ObterSalaReuniao (Guid id)
        {
            return await Db.Salas.AsNoTracking().FirstOrDefaultAsync( p => p.Id == id );
        }

        public async Task<IEnumerable<Sala>> ObterSalasReunioes ()
        {
            return await Db.Salas.AsNoTracking().OrderBy( p => p.Nome).ToListAsync();
        }
    }
}
