using Microsoft.EntityFrameworkCore;
using Muzeum.Data.Sql.DAO;
using Muzeum.Data.Sql.DAOConfigurations;

namespace Muzeum.Data.Sql
{
    public class MuzeumDbContext : DbContext
    {
        public MuzeumDbContext(DbContextOptions<MuzeumDbContext> options) : base(options) {}

        public virtual DbSet<Eksponat> Eksponat { get; set; }
        public virtual DbSet<Gosc> Gosc { get; set; }
        public virtual DbSet<Magazyn> Magazyn { get; set; }
        public virtual DbSet<DAO.Pracownik> Pracownik { get; set; }
        public virtual DbSet<Serwis> Serwis { get; set; }
        public virtual DbSet<Wizyta> Wizyta { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EksponatConfiguration());
            builder.ApplyConfiguration(new GoscConfiguration());
            builder.ApplyConfiguration(new MagazynConfiguration());
            builder.ApplyConfiguration(new PracownikConfiguration());
            builder.ApplyConfiguration(new SerwisConfiguration());
            builder.ApplyConfiguration(new WizytaConfiguration());

        }
        
    }
}