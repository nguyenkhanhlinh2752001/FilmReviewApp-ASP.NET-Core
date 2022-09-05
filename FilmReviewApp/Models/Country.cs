using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmReviewApp.Models
{
    [Table("Country")]
    public class Country
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
