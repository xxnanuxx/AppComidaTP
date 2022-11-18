using System.ComponentModel.DataAnnotations;

namespace AppComidaTP.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public string Comida { get; set; }
        public string Bebida { get; set; }
        public string Postre { get; set; }
        [Required]
        public float Total { get; set; }
        [Required]
        public string DniCliente { get; set; }
    }
}
