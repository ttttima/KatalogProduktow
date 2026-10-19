using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4K
{
    internal class produkt
    {
        private double _cena;

        public string nazwa { get; set; } = "";

        public double cena
        {
            get { return _cena; }
            set { _cena = value < 0 ? 0 : value; }
        }

        public string ilosc { get; set; } = "";
        public string kategoria { get; set; } = "";

        public override string ToString()
        {
            return $"{nazwa}, kategoria: {kategoria}, cena: {cena:F2} zł, ilość: {ilosc}";
        }
    }
}
