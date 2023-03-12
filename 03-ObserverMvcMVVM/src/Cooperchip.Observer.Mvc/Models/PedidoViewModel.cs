using Cooperchip.Observer.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.Observer.Mvc.Models
{
    public class PedidoViewModel
    {
        [Key]
        [Display(Name = "ID do Pedido")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Número")]
        [StringLength(15, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Numero { get; set; }
        
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Valor do Pedido")]
        [DataType(DataType.Currency, ErrorMessage = "Valor Inválido!")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Status do Pedido")]
        public StatusDoPedido Status { get; set; }
    }
}