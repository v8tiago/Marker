using Marker.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marker.Business.Interfaces
{
    public interface IReuniaoRepository : IRepository<Reuniao>
    {
        Task<IEnumerable<Reuniao>> ObterReuniaoPorSala (Guid salaId);
        Task<Reuniao> ObterReuniaoSala (Guid id);
    }
}
