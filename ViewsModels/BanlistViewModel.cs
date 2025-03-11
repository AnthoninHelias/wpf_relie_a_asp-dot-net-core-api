using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Models;


namespace WpfApp1.ViewModel
{
    public class BanlistViewModel
    {
        private readonly HttpClient _httpClient;
        public ObservableCollection<Banlist> Banlists { get; set; }
        public ICommand LoadBanlistsCommand { get; set; }
        public ICommand AddBanlistCommand { get; set; }
        public ICommand UpdateBanlistCommand { get; set; }
        public ICommand DeleteBanlistCommand { get; set; }

        public BanlistViewModel()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(" http://localhost:5193/api/Banlist/") };
            Banlists = new ObservableCollection<Banlist>();

            // Commande sans argument
            AddBanlistCommand = new RelayCommand<Banlist>(async banlist => await AddBanlist(banlist));
            //UpdateBanlistCommand = new RelayCommand(UpdateBanlist);
            DeleteBanlistCommand = new RelayCommand<int>(async id => await DeleteBanlist(id));

            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                List<Banlist> fetchedSBanlist = await _httpClient.GetFromJsonAsync<List<Banlist>>("http://localhost:5193/api/Banlist/GetBanlists");

               // var response = await _httpClient.GetStringAsync("GetBanlists");
               // Trace.WriteLine($"[GET] /GetBanlists - Réponse reçue avec succès");
               

              //  var data = JsonSerializer.Deserialize<ObservableCollection<Banlist>>(response);

                Banlists.Clear();
                foreach (var item in fetchedSBanlist)
                {
                    
                    Banlists.Add(item);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[GET] /GetBanlists - Erreur: {ex.Message}");
            }
        }

        public async Task AddBanlist(Banlist banlist)
        {
            try
            {
                var json = JsonSerializer.Serialize(banlist);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/InsertBanlist", content);

                if (response.IsSuccessStatusCode)
                {
                    Trace.WriteLine($"[POST] /InsertBanlist - Succès: {response.StatusCode}");
                    LoadData();
                }
                else
                {
                    Trace.WriteLine($"[POST] /InsertBanlist - Erreur: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[POST] /InsertBanlist - Exception: {ex.Message}");
            }
        }

        public async Task UpdateBanlist(Banlist banlist)
        {
            try
            {
                var json = JsonSerializer.Serialize(banlist);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync("/UpdateBanlist", content);

                if (response.IsSuccessStatusCode)
                {
                    Trace.WriteLine($"[PUT] /UpdateBanlist - Succès: {response.StatusCode}");
                    LoadData();
                }
                else
                {
                    Trace.WriteLine($"[PUT] /UpdateBanlist - Erreur: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[PUT] /UpdateBanlist - Exception: {ex.Message}");
            }
        }

        public async Task DeleteBanlist(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/DeleteBanlist/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Trace.WriteLine($"[DELETE] /DeleteBanlist/{id} - Succès: {response.StatusCode}");
                    LoadData();
                }
                else
                {
                    Trace.WriteLine($"[DELETE] /DeleteBanlist/{id} - Erreur: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"[DELETE] /DeleteBanlist/{id} - Exception: {ex.Message}");
            }
        }
    }
}
