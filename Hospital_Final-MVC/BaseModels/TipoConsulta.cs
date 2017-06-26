using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class TipoConsulta
    {
        [Key]
        public int TipoConsultaID { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        public float Valor { get; set; }
    }
}
