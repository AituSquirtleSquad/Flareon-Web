using FlareonWeb.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlareonWeb.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string CinemaName { get; set; }
        public string CinemaCity { get; set; }
        public string CinemaAddress { get; set; }

        //Relations
        public List<Movie> Movies { get; set; }

    }
}
