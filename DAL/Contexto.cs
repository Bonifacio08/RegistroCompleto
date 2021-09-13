using Microsoft.EntityFrameworkCore;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.DAL
{
    //Simpre agregar public
    public class Contexto : DbContext
    {
        public DbSet<Roll> Roll { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\TeacherControl.db");
        }
    }
}
