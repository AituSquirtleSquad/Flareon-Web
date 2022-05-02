using FlareonWeb.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlareonWeb.Models
{
    public class Theater
    {
        public int TheaterId { get; set; }
        [Required(ErrorMessage = "Theater Name is required")]
        public string TheaterName { get; set; }
        [Required(ErrorMessage = "Theater City is required")]
        public string TheaterCity { get; set; }
        [Required(ErrorMessage = "Theater Address is required")]
        public string TheaterAddress { get; set; }

        //Relations
        public List<Spectacle> Spectacles { get; set; }

    }
}
