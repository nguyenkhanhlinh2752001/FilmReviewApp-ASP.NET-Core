using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmReviewApp.Models
{
    [Table("Review")]
    public class Review
    {
        [Key] 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Reviewer Reviewer { get; set; }
        public Film Film { get; set; }

    }
}
