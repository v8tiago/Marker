using Marker.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Marker.Business.Interfaces
{
    public interface ISalaRepository : IRepository<Sala>
    {
        Task<Sala> ObterSalaReuniao (Guid id);
        Task<IEnumerable<Sala>> ObterSalasReunioes ();
    }
}
