using Blog.Shared.Data.GG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Blog.Client.Services.GoodGameService
{
    public class GoodGameService : IGoodGameService
    {
        private readonly HttpClient _httpclient;
        public GGStreams Streams = new GGStreams();

        public GoodGameService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<GGStreams> GetStreams()
        {
            HttpResponseMessage response = await _httpclient.GetAsync("https://api2.goodgame.ru/v2/streams?adult=false&only_gg=true");
            if (response.IsSuccessStatusCode)
            {
                Streams = await response.Content.ReadFromJsonAsync<GGStreams>();
            }
            else
            {
                return Streams;
            }

            if (Streams.page_count > 1)
            {
                for (int PageStart = 2; PageStart <= Streams.page_count; PageStart++)
                {
                    GGStreams AddNewValue = await _httpclient.GetFromJsonAsync<GGStreams>("https://api2.goodgame.ru/v2/streams?adult=false&only_gg=true&page=" + PageStart);
                    foreach (var itemStream in AddNewValue._embedded.streams)
                    {
                        Streams._embedded.streams.Add(itemStream);
                    }
                }
            }
            return Streams;
        }
    }
}
