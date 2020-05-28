using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SFF_Api_App.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Grade { get; set; }
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }
        public ICollection<Trivias> Trivia { get; set; } = new List<Trivias>();
    }
}
