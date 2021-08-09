using Blog.Shared.Data.GG;
using System.Threading.Tasks;

namespace Blog.Client.Services.GoodGameService
{
    public interface IGoodGameService
    {
        Task<GGStreams> GetStreams();
    }
}
