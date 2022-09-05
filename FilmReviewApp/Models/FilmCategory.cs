using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmReviewApp.Models
{
    [Table("FilmCategory")]
    public class FilmCategory
    {
        public int FilmId { get; set; }
        public int CategoryId { get; set; }
        public Film Film { get; set; }
        public Category Category { get; set; }
    }
}
