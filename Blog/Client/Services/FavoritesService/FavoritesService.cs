using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Blog.Shared.Data;
using Blog.Shared.Data.GG;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blog.Client.Services.FavoritesService
{
    public class FavoritesService : IFavoritesService
    {
        private readonly ILocalStorageService _localstorage;
        private readonly IToastService _toastservice;
        private readonly HttpClient _httpclient;

        public event Action OnChange;
        public FavoritesService(ILocalStorageService localstorage, IToastService toastservice, HttpClient httpclient)
        {
            _localstorage = localstorage;
            _toastservice = toastservice;
            _httpclient = httpclient;
        }

        public async Task AddToFavorites(Stream stream)
        {
            var favorites = await GetAllFavorites();
            Favorite newfavorite = new Favorite
            {
                Id = stream.id,
                Link = stream.url,
                Status = stream.status,
                Name = stream.key,
                _platform = 0,
                PlayerId = stream.channel.gg_player_src.ToString(),
                AvataUrl = await GetUrlAvatarFromGG(stream.channel.gg_player_src.ToString())
            };
            if (favorites.Exists(x => x.Id == newfavorite.Id) == true)
            {
                _toastservice.ShowWarning(newfavorite.Name, "!!! Уже есть в отслеживаемом !!!");
                return;
            }
            else
            {
                favorites.Add(newfavorite);
                await _localstorage.SetItemAsync("favorites", favorites);
                _toastservice.ShowSuccess(newfavorite.Name, "Теперь отслеживается!");
            }
            await CheckStatusOnline();
            OnChange.Invoke();
        }

        public async Task<List<Favorite>> GetAllFavorites()
        {
            List<Favorite> favorites = await _localstorage.GetItemAsync<List<Favorite>>("favorites");
            if (favorites == null)
            {
                favorites = new List<Favorite>();
            }
            return favorites;
        }

        public async Task DeleteFavorite(Favorite favorite)
        {
            var favorites = await GetAllFavorites();
            if (favorites.Count <= 0) { return; }
            var favoriteItem = favorites.Find(x => x.Id == favorite.Id);
            _toastservice.ShowSuccess(favoriteItem.Name, "Стерт из отслеживаемого!");
            favorites.Remove(favoriteItem);
            await _localstorage.SetItemAsync("favorites", favorites);
            await CheckStatusOnline();
            OnChange.Invoke();
        }
        private async Task<string> GetUrlAvatarFromGG(string playerid)
        {
            int reqid;
            if (int.TryParse(playerid, out reqid))
            {
                HttpResponseMessage response = await _httpclient.GetAsync("https://api2.goodgame.ru/player/" + playerid);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<GGPlayerId>();
                    return result.streamer_avatar;
                }
            }
            return "";
        }
        public async Task CheckStatusOnline()
        {
            var favorites = await GetAllFavorites();
            if (favorites.Count <= 0)
            {
                return;
            }
            foreach (var favorite in favorites)
            {
                HttpResponseMessage response = await _httpclient.GetAsync("https://api2.goodgame.ru/player/" + favorite.PlayerId);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<GGPlayerId>();
                    favorite.Status = result.channel_status;
                }
            }
            await _localstorage.SetItemAsync("favorites", favorites);
        }
    }
}
