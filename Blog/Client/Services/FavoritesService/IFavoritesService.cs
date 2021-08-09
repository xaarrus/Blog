using Blog.Shared.Data;
using Blog.Shared.Data.GG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Client.Services.FavoritesService
{
    public interface IFavoritesService
    {
        event Action OnChange;
        Task<List<Favorite>> GetAllFavorites();
        Task AddToFavorites(Stream stream);
        Task DeleteFavorite(Favorite favorite);
        Task CheckStatusOnline();
    }
}
