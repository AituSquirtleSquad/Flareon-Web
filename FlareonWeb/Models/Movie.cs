using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlareonWeb.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MovieReleaseDate { get; set; }
        public string MovieGenre { get; set; }
        public TimeSpan MovieDuration { get; set; }
        public string MovieImage { get; set; }
        public string MovieBackgroundImage { get; set; }
        public int MoviePrice { get; set; }

        //Relations
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

    }
}
