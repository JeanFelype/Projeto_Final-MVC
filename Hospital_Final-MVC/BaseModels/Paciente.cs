using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Paciente
    {
        [Key]
        public int PacienteID { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        [StringLength(30, ErrorMessage = "O tamanho Max. é de 30 letras")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        [MaxLength(11, ErrorMessage = "O tamanho Max. é de 11 Caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        [DataType(DataType.Date)]
        public string DataNasc { get; set; }
    }
}
