// Fichier : Views/ConnexionWindow.xaml.cs
using System.Windows;
using System.Windows.Controls;
using WpfApp1.ViewsModels;

namespace WpfApp1.Views
{
    public partial class ConnexionWindow : Window
    {
        public ConnexionWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is ConnexionViewModel vm)
            {
                vm.MotDePasse = ((PasswordBox)sender).Password;
            }
        }

    }
}
