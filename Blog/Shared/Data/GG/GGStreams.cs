using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Data.GG
{
    public class GGStreams
    {
        public Links _links { get; set; }
        public Embedded _embedded { get; set; }
        public int page_count { get; set; }
        public int page_size { get; set; }
        public int total_items { get; set; }
        public int page { get; set; }
    }
    public class Stream
    {
        public string request_key { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public bool is_broadcast { get; set; }
        public int broadcast_started { get; set; }
        public int broadcast_end { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public int viewers { get; set; }
        public int player_viewers { get; set; }
        public int users_in_chat { get; set; }
        public Channel channel { get; set; }
        public Links _links { get; set; }
    }
    public class Embedded
    {
        public List<Stream> streams { get; set; }
    }
    public class Self
    {
        public string href { get; set; }
    }

    public class First
    {
        public string href { get; set; }
    }

    public class Last
    {
        public string href { get; set; }
    }

    public class Next
    {
        public string href { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public First first { get; set; }
        public Last last { get; set; }
        public Next next { get; set; }
    }

    public class Game
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class Channel
    {
        public int id { get; set; }
        public string key { get; set; }
        public string premium { get; set; }
        public string title { get; set; }
        public int max_viewers { get; set; }
        public string player_type { get; set; }
        public object gg_player_src { get; set; }
        public string embed { get; set; }
        public string img { get; set; }
        public string thumb { get; set; }
        public string description { get; set; }
        public bool adult { get; set; }
        public List<Game> games { get; set; }
        public string url { get; set; }
    }
}
