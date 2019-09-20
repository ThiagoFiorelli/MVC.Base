

using System.ComponentModel.DataAnnotations;

namespace BaseDDD.MVC.ViewModels
{
    public class PedidoItemViewModel
    {
        [Key]
        public int PedidoId { get; set; }

        [Key]
        public int ProdutoId { get; set; }
    }
}