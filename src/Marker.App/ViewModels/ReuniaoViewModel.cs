using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marker.App.ViewModels
{
    public class ReuniaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required( ErrorMessage = "O campo {0} é obrigatório" )]
        [DisplayName("Sala")]
        public Guid SalaId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataInicio { get; set; }

        [ScaffoldColumn( false )]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage ="O campo {0} preisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Assunto { get; set; }

        //EF Relations

        public SalaViewModel Sala { get; set; }
    }
}
