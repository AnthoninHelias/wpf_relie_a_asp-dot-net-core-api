using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Input;
using WpfApp1.Models;


namespace WpfApp1.ViewModel
{
    public class BanlistViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Banlist> Banlists { get; set; }

        public BanlistViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5193/api/") };
            Banlists = new ObservableCollection<Banlist>();
            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/GetBanlists");
                var data = JsonSerializer.Deserialize<ObservableCollection<Banlist>>(response);
                Banlists.Clear();
                foreach (var item in data)
                {
                    Banlists.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
        }

        public async Task AddBanlist(Banlist banlist)
        {
            var json = JsonSerializer.Serialize(banlist);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("/InsertBanlist", content);
            LoadData();
        }

        public async Task UpdateBanlist(Banlist banlist)
        {
            var json = JsonSerializer.Serialize(banlist);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("/UpdateBanlist", content);
            LoadData();
        }

        public async Task DeleteBanlist(int id)
        {
            await _httpClient.DeleteAsync($"/DeleteBanlist/{id}");
            LoadData();
        }
    }
}
