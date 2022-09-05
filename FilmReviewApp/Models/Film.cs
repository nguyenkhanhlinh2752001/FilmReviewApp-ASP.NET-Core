using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmReviewApp.Models
{
    [Table("Film")]
    public class Film
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<FilmActor> FilmActors { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
