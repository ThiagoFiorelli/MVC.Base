

using BaseDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseDDD.MVC.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public int PedidoId { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal ValorTotal { get; set; }

        public int Status { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}