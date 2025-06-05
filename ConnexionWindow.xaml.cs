using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class ConnexionWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5193/api/Utilisateur/") };

        public ConnexionWindow()
        {
            InitializeComponent();
        }

        private async void SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomUtilisateurTextBox.Text) || string.IsNullOrWhiteSpace(MotDePassePasswordBox.Password))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            var utilisateur = new Utilisateur
            {
                nom = NomUtilisateurTextBox.Text,
                motDePasse = MotDePassePasswordBox.Password
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("VerifyUtilisateur", utilisateur);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    if (result.Trim('"') == "true")
                    {
                        MessageBox.Show("Connected", "Connexion", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Vider les champs après connexion réussie
                        NomUtilisateurTextBox.Text = "";
                        MotDePassePasswordBox.Password = "";

                        // Fermer la MainWindow et cette fenêtre
                        Application.Current.MainWindow?.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erreur de connexion : {errorMessage}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion avec l'API : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            // Créer et afficher une nouvelle MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            // Fermer cette fenêtre
            this.Close();
        }

        private void Vider_Click(object sender, RoutedEventArgs e)
        {
            NomUtilisateurTextBox.Text = "";
            MotDePassePasswordBox.Password = "";
        }
    }

    public class Utilisateur
    {
        public string nom { get; set; }
        public string motDePasse { get; set; }
    }
}