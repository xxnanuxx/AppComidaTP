namespace AppComidaTP.Models
{
    public class ViewModel
    {
        private List<Comida> comidas;
        private List<Bebida> bebidas;
        private List<Postre> postres;

        public ViewModel(List<Comida> Comidas, List<Bebida> Bebidas, List<Postre> Postres)
        {
            this.comidas = Comidas;
            this.bebidas = Bebidas;
            this.postres = Postres;
        }

        public IEnumerable<Comida> enComidas { get { return this.comidas; } }
        public IEnumerable<Bebida> enBebidas { get { return this.bebidas; } }
        public IEnumerable<Postre> enPostres { get { return this.postres; } }
    }
}
