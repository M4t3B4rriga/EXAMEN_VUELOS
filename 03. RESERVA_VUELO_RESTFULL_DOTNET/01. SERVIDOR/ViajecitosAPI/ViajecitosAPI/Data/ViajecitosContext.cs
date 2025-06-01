using Microsoft.EntityFrameworkCore;
using ViajecitosAPI.ec.edu.monster.modelo;
namespace ViajecitosAPI.Data
{
    public class ViajecitosContext : DbContext
    {
        public ViajecitosContext(DbContextOptions<ViajecitosContext> options) : base(options) { }

        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}