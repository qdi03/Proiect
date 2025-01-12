using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ProiectContext : DbContext
    {
        public ProiectContext (DbContextOptions<ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect.Models.Tatuaj> Tatuaj { get; set; } = default!;
        public DbSet<Proiect.Models.Salon> Salon { get; set; } = default!;
        public DbSet<Proiect.Models.Artist> Artist { get; set; } = default!;
        public DbSet<Proiect.Models.Category> Category { get; set; } = default!;
        public DbSet<Proiect.Models.Client> Client { get; set; } = default!;
        public DbSet<Proiect.Models.Appointment> Appointment { get; set; } = default!;
    }
}
