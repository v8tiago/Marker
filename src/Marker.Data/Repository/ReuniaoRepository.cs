using Marker.Business.Interfaces;
using Marker.Business.Models;
using Marker.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marker.Data.Repository
{
    public class ReuniaoRepository : Repository<Reuniao>, IReuniaoRepository
    {
        public ReuniaoRepository(MeuDbContext context) : base(context) {}

        public async Task<IEnumerable<Reuniao>> ObterReuniaoPorSala (Guid salaId)
        {
            return await Db.Reunioes.AsNoTracking().Include( s => s.Sala ).OrderBy( r => r.Id == salaId ).ToListAsync();
        }

        public async Task<Reuniao> ObterReuniaoSala (Guid id)
        {
            return await Db.Reunioes.AsNoTracking().Include( s => s.Sala ).FirstOrDefaultAsync( r => r.Id == id );
        }
    }
}
