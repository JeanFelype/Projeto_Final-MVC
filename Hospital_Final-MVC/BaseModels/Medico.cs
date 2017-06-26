using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Medico
    {
        [Key]
        public int MedicoID { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        [StringLength(30, ErrorMessage = "O tamanho Max. é de 30 letras")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        [MaxLength(8, ErrorMessage = "O tamanho Max. é de 8 Caracteres")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio!")]
        [DataType(DataType.Date)]
        public string DataNasc { get; set; }
    }
}
