using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmReviewApp.Models
{
    [Table("Reviewer")]
    public class Reviewer
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set;}
        public string Gender { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
