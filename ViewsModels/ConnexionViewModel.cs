// Fichier : ViewsModels/ConnexionViewModel.cs
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Modelss;

namespace WpfApp1.ViewsModels
{
    public class ConnexionViewModel : INotifyPropertyChanged
    {
        private string _nom;
        public string Nom
        {
            get => _nom;
            set { _nom = value; OnPropertyChanged(); }
        }

        public string MotDePasse { get; set; }

        public ICommand ConnexionCommand { get; }

        public ConnexionViewModel()
        {
            ConnexionCommand = new RelayCommand(async _ => await ConnexionAsync());
        }

        private async Task ConnexionAsync()
        {
            try
            {
                var utilisateur = new Utilisateur
                {
                    Nom = this.Nom,
                    MotDePasse = this.MotDePasse
                };

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5000"); // <-- Change l'URL si besoin

                var response = await client.PostAsJsonAsync("/VerifyUtilisateur", utilisateur);

                if (response.IsSuccessStatusCode)
                {
                    var isValid = await response.Content.ReadFromJsonAsync<bool>();

                    if (isValid)
                    {
                        MessageBox.Show("✅ Connexion réussie !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("❌ Nom ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Erreur HTTP: {response.StatusCode}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
