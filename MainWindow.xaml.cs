using System.Net.Http;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Cartes_Click(object sender, RoutedEventArgs e)
        {
            CartesWindow cartesWindow = new CartesWindow();
            cartesWindow.Show();
        }

        private void BanListe_Click(object sender, RoutedEventArgs e)
        {
            BanListeWindow banListeWindow = new BanListeWindow();
            banListeWindow.Show();
        }
         private void Connexion_Click(object sender, RoutedEventArgs e)
        {
            ConnexionWindow connexionWindow = new ConnexionWindow();
            connexionWindow.Show();
            this.Close(); // Fermer la MainWindow
        }

    }
}
