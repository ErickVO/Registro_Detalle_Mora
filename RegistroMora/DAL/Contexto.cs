using Microsoft.EntityFrameworkCore;
using RegistroMora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroMora.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Mora> Moras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\MoraDB.db");
        }
    }
}
