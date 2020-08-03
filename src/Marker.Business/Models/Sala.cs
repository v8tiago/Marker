using System;
using System.Collections.Generic;
using System.Text;

namespace Marker.Business.Models
{
    public class Sala : Entity
    {

        public string Nome { get; set; }
        public Unidade Unidade { get; set; }

        //EF Relations
        public IEnumerable<Reuniao> Reunioes { get; set; }
    }
}
