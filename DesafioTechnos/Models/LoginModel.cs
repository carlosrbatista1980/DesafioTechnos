using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTechnos.Models
{
    public class LoginModel
    {
        public string token { get; set; }

        [Required]
        [DefaultValue("envie um nome qualquer de usuario para a geração do token com validade de 1 hora")]
        public string usuario { get; set; }
    }
}
