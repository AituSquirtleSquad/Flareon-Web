using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlareonWeb.Models
{
    public class Spectacle
    {
        public int SpectacleId { get; set; }
        public string SpectacleName { get; set; }
        public string SpectacleDescription { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SpectacleReleaseDate { get; set; }
        public string SpectacleGenre { get; set; }
        public TimeSpan SpectacleDuration { get; set; }
        public string SpectacleImage { get; set; }
        public string SpectacleBackgroundImage { get; set; }
        public int SpectaclePrice { get; set; }


        //Relationships
        public int TheaterId { get; set; }
        [ForeignKey("TheaterId")]
        public Theater Theater { get; set; }

    }
}
