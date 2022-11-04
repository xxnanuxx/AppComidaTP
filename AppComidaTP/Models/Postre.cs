using System.ComponentModel.DataAnnotations;

namespace AppComidaTP.Models
{
    public class Postre
    {
        [Key]
        public string Codigo { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
