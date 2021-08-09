using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Data.GG
{
    public class GGPlayerId
    {
        public string channel_id { get; set; }
        public string channel_key { get; set; }
        public string channel_title { get; set; }
        public string channel_status { get; set; }
        public string channel_poster { get; set; }
        public bool channel_premium { get; set; }
        public string streamer_name { get; set; }
        public string streamer_avatar { get; set; }
        public bool premium_only { get; set; }
        public int adult { get; set; }
        public string channel_start { get; set; }
        public string ga_code { get; set; }
        public Links _links { get; set; }
    }
}
