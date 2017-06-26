using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Consulta
    {
        [Key]
        public int ConsultaID { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]

        public int PacienteID { get; set; }
        public virtual Paciente _Paciente { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        public int MedicoID { get; set; }
        public virtual Medico _Medico { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        public int TipoConsultaID { get; set; }
        public virtual TipoConsulta _TipoConsulta { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        [DataType(DataType.Date)]
        public string DataConsulta { get; set; }
    }
}
