using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Shared.Data
{
    public class Note
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
