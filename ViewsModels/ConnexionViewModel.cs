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

        private string _motDePasse;
        public string MotDePasse
        {
            get => _motDePasse;
            set { _motDePasse = value; OnPropertyChanged(); }
        }

        public ICommand ConnexionCommand { get; }

        public ConnexionViewModel()
        {
            ConnexionCommand = new RelayCommand(async () => await ConnexionAsync());
        }

        private async Task ConnexionAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Nom) || string.IsNullOrWhiteSpace(MotDePasse))
                {
                    MessageBox.Show("Veuillez remplir tous les champs.");
                    return;
                }

                var utilisateur = new Utilisateur
                {
                    nom = this.Nom,
                    motDePasse = this.MotDePasse
                };

                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5193/api/Auth/");

                var response = await client.PostAsJsonAsync("Login", utilisateur);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Connected", "Connexion", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    // Vider les champs après connexion réussie
                    Nom = "";
                    MotDePasse = "";
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erreur de connexion : {errorMessage}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion avec l'API : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    // Classe RelayCommand pour ICommand
    public class RelayCommand : ICommand
    {
        private readonly Func<Task> _executeAsync;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Func<Task> executeAsync, Func<bool> canExecute = null)
        {
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public async void Execute(object parameter) => await _executeAsync();
    }

    // Classe Utilisateur si elle n'existe pas ailleurs
    public class Utilisateur
    {
        public string nom { get; set; }
        public string motDePasse { get; set; }
    }
}