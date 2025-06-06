using Microsoft.EntityFrameworkCore;
using VotacionesWebControlador.Entidades;

namespace VotacionesWebBack.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Votante> Votantes { get; set; }


    }
}
