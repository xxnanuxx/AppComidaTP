using System.ComponentModel.DataAnnotations;

namespace AppComidaTP.Models
{
    public class Cliente
    {
        [Key]
        public int Dni { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string MetodoPago { get; set; }
    }
}
