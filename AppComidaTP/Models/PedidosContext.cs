using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AppComidaTP.Models
{
    public class PedidosContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder opcion)
        {
            opcion.UseSqlServer("Data Source=DESKTOP-FBMEF1V; Initial Catalog=PedidosBD; Integrated Security=true");
        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Comida> Alimentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
