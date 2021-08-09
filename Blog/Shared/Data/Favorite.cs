using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Data
{
    public class Favorite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }
        public string PlayerId { get; set; }
        public string AvataUrl { get; set; }
        public Platform _platform { get; set; }
    }
    public enum Platform
    {
        GG,
        YT,
        TW
    }
}
