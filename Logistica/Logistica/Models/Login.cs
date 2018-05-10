using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class Login
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Usuario { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Senha { get; set; }
    }
}