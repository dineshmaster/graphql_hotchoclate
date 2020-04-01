using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Cinema.Model.Entity;

namespace Cinema.Model.CoreData
{
    public class CinemaDbContext:DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options):base(options)
        {

        }
        public DbSet<Cinema.Model.Entity.Cinema> Cinemas { get; set; }
    }
}
