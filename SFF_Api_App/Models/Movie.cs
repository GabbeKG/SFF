using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFF_Api_App.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Genre { get; set; }

        public int Stock { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
