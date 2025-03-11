using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class CartesWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5193/api/Carte/") };
        private List<Carte> _cartes = new List<Carte>();
        private Carte _selectedCarte;

        public CartesWindow()
        {
            InitializeComponent();
            ChargerCartes();
        }

        private async void ChargerCartes()
        {
            try
            {
                _cartes = await _httpClient.GetFromJsonAsync<List<Carte>>("GetCartes");
                CartesDataGrid.ItemsSource = _cartes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des cartes : " + ex.Message);
            }
        }

        private async void AjouterCarte_Click(object sender, RoutedEventArgs e)
        {
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

        private void CartesDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedCarte = (Carte)CartesDataGrid.SelectedItem;
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

            var response = await _httpClient.PutAsJsonAsync("UpdateCarte", _selectedCarte);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Carte modifiée avec succès.");
                ChargerCartes();
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification de la carte.");
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
                ChargerCartes();
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
