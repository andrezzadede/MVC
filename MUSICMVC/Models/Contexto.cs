using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/* Classes adicionadas */
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace MVCWEB.Models
{
    public class Contexto: DbContext
    {
        /* Define o nome do Banco que será Criado */
        public Contexto() : base("MVCMusic") { }

        public DbSet<Artista> artistas { get; set; }
        public DbSet<Evento> eventos { get; set; }
        public DbSet<Rank> ranks { get; set; }
    }
}