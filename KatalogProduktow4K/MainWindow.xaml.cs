using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KatalogProduktow4K
{
    public partial class MainWindow : Window
    {
        List<produkt> produkty = new List<produkt>();
        public MainWindow()
        {
            InitializeComponent();
            KategorieComboBox.ItemsSource = new string[] { "Elektronika", "Odzież", "Książki", "Meble" };
            KategorieComboBox.SelectedIndex = 0;

            produkty.Add(new produkt
            {   
                nazwa = "Laptop",
                cena = 4599.99,
                ilosc = "5",
                kategoria = "Elektronika"
            });

            produkty.Add(new produkt
            {
                nazwa = "Koszulka",
                cena = 120,
                ilosc = "12",
                kategoria = "Odzież"
            });

            ListaProdoktow.ItemsSource = produkty;
        }

        private void Oblicz(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(CenaTextBox.Text, out double cena) || cena < 0)
            {
                WynikTextBlock.Text = "Podaj nieujemną, poprawną cenę.";
                return;
            }

            if (!int.TryParse(IloscTextBox.Text, out int ilosc) || ilosc < 0)
            {
                WynikTextBlock.Text = "Podaj nieujemną, poprawną ilość.";
                return;
            }

            double wartoscZamowienia = cena * ilosc;

            if (PromocjaCheckBox.IsChecked == true)
            {
                wartoscZamowienia *= 0.9;
            }

            WynikTextBlock.Text = $"Nazwa produktu: {NazwaTextBox.Text}\n" +
                                  $"Kategoria: {KategorieComboBox.SelectedItem}\n" +
                                  $"Cena: {cena:F2} zł\n" +
                                  $"Ilość: {ilosc}\n" +
                                  $"Wartość zamówienia: {wartoscZamowienia:F2} zł";
        }
    }
}
