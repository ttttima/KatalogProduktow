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
using System.Collections.ObjectModel;

namespace KatalogProduktow4K
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Produkt> Produkty { get; } = new();
        public MainWindow()
        {
            InitializeComponent();
            KategorieComboBox.ItemsSource = new string[] { "Elektronika", "Odzież", "Książki", "Meble" };
            KategorieComboBox.SelectedIndex = 0;

            Produkty.Add(new Produkt { Nazwa = "Laptop", Cena = 3500, Ilosc = 5, Kategoria = "Elektronika" });
            Produkty.Add(new Produkt { Nazwa = "Koszula", Cena = 120, Ilosc = 10, Kategoria = "Odzież" });

            // Binding DataGrid.ItemsSource -> Produkty.
            DataContext = this;
        }

        private void Oblicz(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(CenaTextBox.Text, out double cena) || cena < 0)
            {
                WynikTextBlock.Text = "Niepoprawna wartość ceny";
                return;
            }

            if (!int.TryParse(IloscTextBox.Text, out int ilosc) || ilosc < 0)
            {
                WynikTextBlock.Text = "Niepoprawna wartość ilości";
                return;
            }

            string kategoria = KategorieComboBox.SelectedItem as string ?? "brak kategorii";
            double wartoscZamowienia = cena * ilosc;

            if (PromocjaCheckBox.IsChecked == true)
            {
                wartoscZamowienia *= 0.9;   // promocja -10%
            }

            WynikTextBlock.Text = $"{NazwaTextBox.Text} ({kategoria}): {wartoscZamowienia:F2} zł";
        }

        private void DodajProdukt(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(CenaTextBox.Text, out double cena) || cena < 0 ||
                !int.TryParse(IloscTextBox.Text, out int ilosc) || ilosc < 0)
            {
                MessageBox.Show("Podaj poprawną, nieujemną cenę i ilość.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string kategoria = KategorieComboBox.SelectedItem as string ?? "brak kategorii";
            Produkty.Add(new Produkt { Nazwa = NazwaTextBox.Text, Cena = cena, Ilosc = ilosc, Kategoria = kategoria });
        }

        private void UsunProdukt(object sender, RoutedEventArgs e)
        {
            if (ListaProduktow.SelectedItem is Produkt wybranyProdukt)
            {
                Produkty.Remove(wybranyProdukt);
            }
            else
            {
                MessageBox.Show("Nie wybrano produktu do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
