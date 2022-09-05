using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FilmReviewApp.Models
{
    [Table("FilmActor")]
    public class FilmActor
    {
        public int FilmId { get; set; }
        public int ActorId { get; set; }
        public Film Film { get; set; }
        public Actor Actor { get; set; }
    }
}
