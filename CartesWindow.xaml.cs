using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class CartesWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5193/api/Carte/") };
        private ObservableCollection<Carte> _cartes = new ObservableCollection<Carte>();
        private Carte _selectedCarte;

        public CartesWindow()
        {
            InitializeComponent();
            CartesDataGrid.SelectionChanged += CartesDataGrid_SelectionChanged;
            ChargerCartes();
        }

        private async void ChargerCartes()
        {
            try
            {
                var cartes = await _httpClient.GetFromJsonAsync<ObservableCollection<Carte>>("GetCartes");
                if (cartes != null)
                {
                    _cartes = cartes;
                    CartesDataGrid.ItemsSource = _cartes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des cartes : " + ex.Message);
            }
        }

        private async void AjouterCarte_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) || string.IsNullOrWhiteSpace(RaretéTextBox.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            var nouvelleCarte = new Carte
            {
                Nom = NomTextBox.Text,
                Rareté = RaretéTextBox.Text
            };

            var response = await _httpClient.PostAsJsonAsync("InsertCarte", nouvelleCarte);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Carte ajoutée avec succès.");
                ChargerCartes();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout de la carte.");
            }
        }

        private void CartesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedCarte = CartesDataGrid.SelectedItem as Carte;
            if (_selectedCarte != null)
            {
                NomTextBox.Text = _selectedCarte.Nom;
                RaretéTextBox.Text = _selectedCarte.Rareté;
            }
        }

        private async void ModifierCarte_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCarte == null)
            {
                MessageBox.Show("Veuillez sélectionner une carte à modifier.");
                return;
            }

            _selectedCarte.Nom = NomTextBox.Text;
            _selectedCarte.Rareté = RaretéTextBox.Text;

            try
            {
                var response = await _httpClient.PutAsJsonAsync("UpdateCarte", _selectedCarte); // Sans ID dans l’URL

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Carte modifiée avec succès.");
                    ChargerCartes(); // Rafraîchir la liste
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Erreur lors de la modification : {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion avec l'API : " + ex.Message);
            }
        }


        private async void SupprimerCarte_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCarte == null)
            {
                MessageBox.Show("Veuillez sélectionner une carte à supprimer.");
                return;
            }

            var response = await _httpClient.DeleteAsync($"DeleteCarte/{_selectedCarte.Id}");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Carte supprimée avec succès.");
                _cartes.Remove(_selectedCarte); // Supprimer localement sans recharger toute la liste
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression de la carte.");
            }
        }
    }

    public class Carte
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Rareté { get; set; }
    }
}
