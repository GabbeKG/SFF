using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFF_Api_App.Models
{
    public class Rented
    {
        public int Id { get; set; }
        public int? movieId { get; set; }
        public Movie movie { get; set; }
        public int? studioId { get; set; }
        public Studio studio { get; set; }
        public bool rented { get; set; }

    }
}
