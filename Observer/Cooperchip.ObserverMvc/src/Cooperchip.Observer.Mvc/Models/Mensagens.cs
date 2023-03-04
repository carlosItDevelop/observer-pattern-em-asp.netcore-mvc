using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.Observer.Mvc.Models
{
    public class Mensagens
    {
        [Key]
        public Guid Id { get;  set; }

        [Display(Name = "Data do Pedido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(255, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Mensagem { get; set; }
    }
}
