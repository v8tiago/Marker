using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marker.App.ViewModels
{
    public class SalaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório" )]
        [StringLength( 100, ErrorMessage = "O campo {0} preisa ter entre {2} e {1} caracteres", MinimumLength = 2 )]
        public string Nome { get; set; }
        public int Unidade { get; set; }

        //EF Relations
        public IEnumerable<ReuniaoViewModel> Reunioes { get; set; }
    }
}
