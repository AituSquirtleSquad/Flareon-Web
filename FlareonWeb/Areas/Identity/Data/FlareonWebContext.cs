using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlareonWeb.Areas.Identity.Data;
using FlareonWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

namespace FlareonWeb.Data
{
    public class FlareonWebContext : IdentityDbContext<ApplicationUser>
    {
        public FlareonWebContext(DbContextOptions<FlareonWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Spectacle> Spectacles { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

    }
}
