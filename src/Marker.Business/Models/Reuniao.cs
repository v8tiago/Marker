using System;
using System.Collections.Generic;
using System.Text;

namespace Marker.Business.Models
{
    public class Reuniao : Entity
    {

        public Guid SalaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Assunto { get; set; }

        //EF Relations

        public Sala Sala { get; set; }

    }
}
