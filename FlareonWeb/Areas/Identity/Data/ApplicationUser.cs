using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FlareonWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace FlareonWeb.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "varchar(100)")]
        public string FullName { get; set; }


        //Relations
    }
}
