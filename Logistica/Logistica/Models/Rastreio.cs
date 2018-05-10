using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Logistica.Models
{
    public class Rastreio
    {
        [Display(Name = "Cód. Rastreio: ")]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Rastrear { get; set; }

    }
}