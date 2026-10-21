namespace KatalogProduktow4K
{
    public class Produkt
    {
        public string Nazwa { get; set; } = "";
        private double cena;

        public double Cena
        {
            get { return cena; }
            set { cena = value < 0 ? 0 : value; }
        }

        public int Ilosc { get; set; }
        public string Kategoria { get; set; } = "";
    }
}
